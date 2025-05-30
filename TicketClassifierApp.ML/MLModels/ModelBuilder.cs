using Microsoft.ML;
using Microsoft.ML.Data;
using System.IO;

namespace TicketClassifierApp.ML.MLModels
{
    public class ModelBuilder
    {
        private static readonly string _modelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "TicketCategoryModel.zip");

        public static void Train(string dataPath)
        {
            var mlContext = new MLContext();

            // Load data
            var data = mlContext.Data.LoadFromTextFile<ModelInput>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            // Split data
            var splitData = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);

            // Define pipeline
            var pipeline = mlContext.Transforms.Text
                    .FeaturizeText("TitleFeaturized", nameof(ModelInput.Title))
                .Append(mlContext.Transforms.Text
                    .FeaturizeText("DescFeaturized", nameof(ModelInput.Description)))
                .Append(mlContext.Transforms.Concatenate("Features", "TitleFeaturized", "DescFeaturized"))
                .Append(mlContext.Transforms.Conversion.MapValueToKey("Label"))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            // Train
            var model = pipeline.Fit(splitData.TrainSet);

            // Evaluate
            var predictions = model.Transform(splitData.TestSet);
            var metrics = mlContext.MulticlassClassification.Evaluate(predictions);

            Console.WriteLine($"Macro Accuracy: {metrics.MacroAccuracy}");

            // Save model
            mlContext.Model.Save(model, data.Schema, _modelPath);
            Console.WriteLine($"Model saved to: {_modelPath}");
        }

        public static PredictionEngine<ModelInput, ModelOutput> LoadPredictionEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(_modelPath, out _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
