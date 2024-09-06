using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace Services.Text.AITraining.Classification
{
    public class TextPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }
    }
}
