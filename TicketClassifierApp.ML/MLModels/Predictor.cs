using Microsoft.ML;

namespace TicketClassifierApp.ML.MLModels
{
    public class Predictor
    {
        private readonly MLContext _mlContext;
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;

        public Predictor(string modelPath)
        {
            _mlContext = new MLContext();

            // Load trained model
            ITransformer trainedModel = _mlContext.Model.Load(modelPath, out _);
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(trainedModel);
        }

        public string Predict(string title, string description)
        {
            var input = new ModelInput
            {
                Title = title,
                Description = description
            };

            var result = _predictionEngine.Predict(input);
            return result.PredictedCategory;
        }
    }
}

