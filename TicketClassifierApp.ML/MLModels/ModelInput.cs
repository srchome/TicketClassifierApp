using Microsoft.ML.Data;

namespace TicketClassifierApp.ML.MLModels
{
    public class ModelInput
    {
        [LoadColumn(0)]
        public string Title { get; set; }

        [LoadColumn(1)]
        public string Description { get; set; }

        [LoadColumn(2), ColumnName("Label")]
        public string Category { get; set; }
    }
}
