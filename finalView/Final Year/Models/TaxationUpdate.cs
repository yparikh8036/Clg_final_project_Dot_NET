using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Year.Models
{
    public class TaxationUpdate
    {
        public int TaxationUpdateID;
        public int EmployeeId;
        public String Title;
        public String Description;
        public String Photo;
        public DateTime CreateDate;
        public bool IsActive;
        public int TaxationCategoryID;
    }
}
 