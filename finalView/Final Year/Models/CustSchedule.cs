using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Year.Models
{
    public class CustSchedule
    {
        public int CustomerScheduleID;
        public DateTime DueDate;
        public DateTime ActualDate;
        public int CustomerServiceID;
        public String Requirements;
        public String DocFile;
        public bool Status;
    }
}
