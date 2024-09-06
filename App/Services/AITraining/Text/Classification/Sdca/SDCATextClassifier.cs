using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Collections.Generic;
using System.Linq;

namespace Services.Text.AITraining.Classification.Sdca
{
    public class SDCATextClassifier
    {
        private readonly MLContext _mlContext;

        public SDCATextClassifier()
        {
            _mlContext = new MLContext();
        }

        public ITransformer TrainModel(IEnumerable<TrainingData> trainingData)
        {
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = _mlContext.Transforms.Text.FeaturizeText("Features", "Text")
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(_mlContext.MulticlassClassification.Trainers.SdcaNonCalibrated())
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(dataView);
            return model;
        }

        public string Predict(ITransformer model, string text)
        {
            var engine = _mlContext.Model.CreatePredictionEngine<TrainingData, TextPrediction>(model);
            var prediction = engine.Predict(new TrainingData { Text = text });
            return prediction.Prediction;
        }
    }
}