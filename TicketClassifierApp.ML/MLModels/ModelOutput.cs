using Microsoft.ML.Data;

namespace TicketClassifierApp.ML.MLModels
{
    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public string PredictedCategory { get; set; }
    }
}
