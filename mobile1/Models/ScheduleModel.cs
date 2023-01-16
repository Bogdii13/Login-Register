using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile1.Models
{
    public class ScheduleModel
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string AppName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Price { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
