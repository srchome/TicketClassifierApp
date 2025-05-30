using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketClassifierApp.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public string PredictedCategory { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsResolved { get; set; } = false;
    }

}
