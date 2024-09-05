using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Models;

namespace MongoDB.DataAccess { 

    public class DataAccessRecord:DataAccessBase
    {
        // Record collection
        public async Task<RecordModel> GetAnnotatorJobOnDataset(string dataset_id, string annotator_id, bool random)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, dataset_id),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnntatorId == annotator_id && a.AnnotationResult == null)
           );

            var result = (await recordCollection.FindAsync(filter)).ToList();
            if(result.Count() > 0)
            {
                if (random) 
                {
                    Random r = new Random();
                    return result[r.Next(0, result.Count() - 1)];
                }
                else
                    return result[0];
            }
            return null;
        }

        // This function to get the AI result on one record for an annotator 
        public async Task<AnnotationResultModel> GetAIJobOnDataset(string recordId, string annotatorId)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r._id, recordId),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnntatorId == annotatorId)
           );

            var result = (await recordCollection.FindAsync(filter)).ToList();

            return result[0].Annotation.First().AIAnnotationResult;
        }
        // This function to get an record
        public async Task<RecordModel> GetRecordById(string Id)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var result = (await recordCollection.FindAsync(r => r._id == Id)).ToList();
            if (result.Count() > 0)
                return result[0];
            return null;
        }
        // This function for saving an annotator job on record
        public async Task SaveAnnotatorJobOnRecord(string recordId, string annotatorId, AnnotationResultModel annotationResult)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var record = GetRecordById(recordId).Result;
            if (record == null) return;

            var cur = record.Annotation.FirstOrDefault(e => e.AnntatorId == annotatorId);
            cur.AnnotationResult = annotationResult;
            cur.AnnotationDate = DateTime.Now;

            var update = Builders<RecordModel>.Update.Set(o => o.Annotation, record.Annotation);
            await recordCollection.UpdateOneAsync(r => r._id == recordId, update);
        }

        // This function for saving the AI result on record
        public async Task SaveAIJobOnRecord(string recordId, string annotatorId, AnnotationResultModel annotationResult)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var record = GetRecordById(recordId).Result;
            if (record == null) return;

            var cur = record.Annotation.FirstOrDefault(e => e.AnntatorId == annotatorId);
            cur.AIAnnotationResult = annotationResult;

            var update = Builders<RecordModel>.Update.Set(o => o.Annotation, record.Annotation);
            await recordCollection.UpdateOneAsync(r => r._id == recordId, update);
        }

        public RecordModel Create(RecordModel newRecord)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            recordCollection.InsertOne(newRecord);
            return newRecord;
        }

        //Report section 
        //helper function
        public async Task<double> GetCountOfAllRecord (string dataset_id) {
                var recordCollection1 = ConnectToMongo<RecordModel>(RecordCollection);
                var filter1 = Builders<RecordModel>.Filter.And(
                   Builders<RecordModel>.Filter.Eq(r => r.DatasetId, dataset_id));
                return (await recordCollection1.FindAsync(filter1)).ToList().Count();
        }

        public async Task<double> GetCountOfWaitingAnnotations(string dataset_id)
        {
            var recordCollection1 = ConnectToMongo<RecordModel>(RecordCollection);
            var filter1 = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, dataset_id),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult == null));
            return (await recordCollection1.FindAsync(filter1)).ToList().Count();
        }

        //helper function 
        public async Task<double> GetCountOfDoneRecord (string datasetId)
        {
            return (await GetDoneRecord(datasetId)).Count();
        }
        // This function for counting done record by AI
        public async Task<double> GetCountOfAIDoneRecord(string datasetId)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AIAnnotationResult != null));
            return (await recordCollection.FindAsync(filter)).ToList().Count();
        }
        // This function for training data
        public async Task<List<RecordModel>> GetDoneRecord(string datasetId)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null));
            return (await recordCollection.FindAsync(filter)).ToList();
        }
        // This function for getting record not served
        public async Task<List<RecordModel>> GetNotCompletedRecord(string datasetId)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult == null));
            return (await recordCollection.FindAsync(filter)).ToList();
        }

        //This function for chart of achievement for each annotator separately
        public async Task<double> GetAnnotatorJobOnTaskForReport(string dataset_id, string annotator_id)
        {
            // solved record for annotator
            var recordsolvedCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, dataset_id),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnntatorId == annotator_id && a.AnnotationResult != null)
           );
            //all record for annotator
            var recordallCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter1 = Builders<RecordModel>.Filter.And(
               Builders<RecordModel>.Filter.Eq(r => r.DatasetId, dataset_id),
               Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnntatorId == annotator_id)
           );

            double result = (await recordsolvedCollection.FindAsync(filter)).ToList().Count();

            double allresult = (await recordallCollection.FindAsync(filter1)).ToList().Count();

            if (allresult > 0)
            {
                return result/ allresult * 100.0;
            }
            return 0;
        }
        //This function for chart of achievement for each annotator separately
        public async Task<double> GetCountOfAllRecordById(string datasetId)
        {
            double res1 = await GetCountOfAllRecord (datasetId);
            double res2 = await GetCountOfDoneRecord(datasetId);
            if (res1 == 0)
                return 0;
            return res2/res1*100.0;
        }

        //This function for chart classes
        /* public async Task<double> GetClassesDistributionAtTask(string className, string datasetId)
         {
             double recordNum = await GetCountOfAllRecord(datasetId);

             className = className.ToLower();

             var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
             var filter = Builders<RecordModel>.Filter.And(
                         Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
                         Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null && a.AnnotationResult.Classes.Any(c => c.ToLower() == className))
                         );
             double res = (await recordCollection.FindAsync(filter)).ToList().Count();
             if (recordNum == 0)
                 return 0;
             return res / recordNum * 100.0;
         }*/
        public async Task<double> GetClassesDistributionAtClassificationTask(string className, string datasetId)
        {
            double recordNum = await GetCountOfAllRecord(datasetId);

            className = className.ToLower();

            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
                        Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
                        Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null && a.AnnotationResult.Classes.Any(c => c.ToLower() == className))
                        );

            double res = (await recordCollection.FindAsync(filter)).ToList().Count();
            if (recordNum == 0)
                return 0;
            return res / recordNum * 100.0;
        }

        public async Task<double> GetClassesDistributionAtTaggingTask(string className, string datasetId)
        {
            double recordNum = await GetCountOfAllRecord(datasetId);

            className = className.ToLower();

            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
                            Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId)
                        );

            var rec = (await recordCollection.FindAsync(filter)).ToList();

            double res = 0;
            foreach (var r in rec)
            {
                foreach (var an in r.Annotation)
                {
                    if (an.AnnotationResult == null) continue;
                    foreach (var cls in an.AnnotationResult.Classes)
                    {
                        if (cls.Split('#').Length == 1 && cls == className)
                            res++;
                        if (cls.Split('#').Length == 2 && cls.Split('#')[1] == className)
                            res++;
                    }
                }
            }

            if (recordNum == 0)
                return 0;
            return res / recordNum * 100.0;
        }

        // This function for achievement chart
        public async Task<List<DateTime>> GetAnnotationDateForTask(string datasetId)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
                         Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
                         Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null)
                         );
            var recordsWithAnnotation = await recordCollection.Find(filter).ToListAsync();

            var annotationResults = recordsWithAnnotation.Select(record => record.Annotation
                                        .Where(a => a.AnnotationResult != null)
                                        .Select(a => a.AnnotationDate)
                                        .FirstOrDefault())
                                        .ToList();
            return annotationResults;
        }
        public async Task<double> GetDoneRecordForAnnotatorsWiththesameresult(string datasetId)
        {
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);

            var filter = Builders<RecordModel>.Filter.And(
                Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
                Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null)
            );

            var recordsWithAnnotation = await recordCollection.Find(filter).ToListAsync();

            var recordsWithSameAnnotationResult = new List<RecordModel>();

            foreach (var record in recordsWithAnnotation)
            {
                var firstAnnotationResult = record?.Annotation?.FirstOrDefault()?.AnnotationResult;

                if (firstAnnotationResult != null && record.Annotation.All(a =>
                    a.AnnotationResult != null &&
                    Enumerable.SequenceEqual(a.AnnotationResult.Classes, firstAnnotationResult.Classes))
                )
                {
                    recordsWithSameAnnotationResult.Add(record);
                }
            }

            return recordsWithSameAnnotationResult.Count();

        }
        public async Task<double> GetCountOfRecordToClass_AForAnnotator_S(string datasetId, string taskclass, string annotatorId) {


            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);

            var filter = Builders<RecordModel>.Filter.And(
                Builders<RecordModel>.Filter.Eq(r => r.DatasetId, datasetId),
                Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null && a.AnnotationResult.Classes.Any(c => c.ToLower() == taskclass.ToLower()) && a.AnntatorId == annotatorId )
            );

            var res = (await recordCollection.FindAsync(filter)).ToList();

            return res.Count();
        
        }
        
        //Dashboard section
        public async Task<double> GetDoneRecordForDate(DateTime date)
        {
            //last date
            var recordCollection = ConnectToMongo<RecordModel>(RecordCollection);
            var filter = Builders<RecordModel>.Filter.And(
                Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationDate >= date && a.AnnotationResult != null)
            );
            var numberofrecord = await recordCollection.Find(filter).ToListAsync();

            //all served record
            var recordCollectionall = ConnectToMongo<RecordModel>(RecordCollection);
            var filterdall = Builders<RecordModel>.Filter.And(
                Builders<RecordModel>.Filter.ElemMatch(r => r.Annotation, a => a.AnnotationResult != null)
            );
            var numberofrecordall = await recordCollectionall.Find(filterdall).ToListAsync();
            if (numberofrecordall.Count() != 0)
                return numberofrecord.Count() / numberofrecordall.Count()*100.0;
            return 0;
        }

    }
}
