using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Year.Models
{
    public class Work
    {
        public int WorkID;
        public int CreatorID;
        public int AssignedID;
        public String Title;
        public String Description;
        public DateTime DueDate;
        public DateTime CreateDate;
        public bool Status;
        public DateTime CompletionDate;
        public String CompletionRemarks;
    }
}