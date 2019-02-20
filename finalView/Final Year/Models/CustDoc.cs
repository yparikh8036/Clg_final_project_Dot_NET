using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Year.Models
{
    public class CustDoc
    {
        public int CustDocID;
        public String DocTitle;
        public String DocFile;
        public String DocRemarks;
        public DateTime IssueDate;
        public DateTime DueDate;
        public int CustomerID;
    }
}