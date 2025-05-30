using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketClassifierApp.ML;
using TicketClassifierApp.ML.MLModels;

namespace TicketClassifierApp.Tests
{
    public class TicketClassifierTests
    {
        [Fact]
        public void Predictor_Returns_Category()
        {
            var modelPath = Path.Combine(AppContext.BaseDirectory, "MLModels", "TicketCategoryModel.zip");
            var predictor = new Predictor(modelPath);

            var result = predictor.Predict("App crashes on login", "App shuts down after entering credentials");

            Assert.False(string.IsNullOrEmpty(result));
        }

    }

}
