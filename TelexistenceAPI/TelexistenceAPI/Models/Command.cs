using System;

namespace TelexistenceAPI.Models
{
    public class Command
    {
        public string Id { get; set; }
        public string CommandText { get; set; }
        public string Robot { get; set; }
        public string User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
