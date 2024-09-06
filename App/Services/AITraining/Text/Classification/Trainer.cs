using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext.UoW;
using MongoDB.Models;
using MongoDB.MongoUOW;
using Services.Text.AITraining.Classification.Sdca;

namespace Services.Text.AITraining.Classification
{
    public class Trainer
    {
        private readonly IUnitOfWork _uow;
        private readonly IMongoUOW _mongoUOW;

        public Trainer(IUnitOfWork uow, IMongoUOW mongoUOW)
        {
            _uow = uow;
            _mongoUOW = mongoUOW;
        }

        public async Task start(string datasetId)
        {
            List<RecordModel> inputData = await _mongoUOW.Record.GetDoneRecord(datasetId);
            List<RecordModel> precdicationData = await _mongoUOW.Record.GetNotCompletedRecord(datasetId);
            List<TrainingData> trainingDataSet = new List<TrainingData>();

            // converting the data from mongo to training data
            foreach(var data in inputData)
            {
                foreach(var annotation in data.Annotation)
                {
                    if (annotation.AnnotationResult == null) continue;
                    trainingDataSet.Add(new TrainingData { Text = data.Data, Label = annotation.AnnotationResult.Classes[0] });
                }
            }

            // training the model
            SDCATextClassifier textClassifier = new SDCATextClassifier();
            var trainedModel = textClassifier.TrainModel(trainingDataSet);

            // storing the AI result into the mongo
            foreach (var data in precdicationData)
            {
                var predictedLabel = textClassifier.Predict(trainedModel, data.Data);
                List<String> classes = new List<string>();
                classes.Add(predictedLabel);
                var result = new AnnotationResultModel { Classes = classes };
                foreach (var annotation in data.Annotation)
                {
                    if (annotation.AnnotationResult != null) continue;
                    await _mongoUOW.Record.SaveAIJobOnRecord(data._id, annotation.AnntatorId, result);
                }
            }
        }
    }
}
