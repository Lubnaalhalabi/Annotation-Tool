using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace Services.Text.AITraining.Classification
{
    public class TrainingData
    {
        public string Text { get; set; }
        public string Label { get; set; }
    }
}
