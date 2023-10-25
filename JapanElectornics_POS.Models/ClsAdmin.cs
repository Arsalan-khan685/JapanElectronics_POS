using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapanElectornics_POS.Models
{
    public class ClsAdmin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public int IsActive { get; set; }
    }
}
