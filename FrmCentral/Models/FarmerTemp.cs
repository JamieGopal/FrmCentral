using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrmCentral.Models
{
    public class FarmerTemp
    {
        // Variable declaration, getters and setters
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }

        // Constructor
        public FarmerTemp(int frmrId, string frmrName)
        {
            FarmerId = frmrId;
            FarmerName = frmrName;
        }

        // Empty Constructor
        public FarmerTemp()
        {

        }

    }
}
