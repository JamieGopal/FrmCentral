using FrmCentral.FrmCentralModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrmCentral.Models
{
    public class FarmerProductFilter
    {

        // Variable declaration, getters and setters

        private List<FrmrProduct> frmrProducts;

        public string FarmerFilter { get; set; }
        public string ProductFilter { get; set; }
        public List<FrmrProduct> FilteredFarmerProductsList { get; set; }

        // Constructor
        public FarmerProductFilter(string farmerFilter, string productFilter, List<FrmrProduct> filteredFarmerProductsList)
        {
            FarmerFilter = farmerFilter;
            ProductFilter = productFilter;
            FilteredFarmerProductsList = filteredFarmerProductsList;
        }

        // Constructor
        public FarmerProductFilter(List<FrmrProduct> farmerProducts)
        {
            this.frmrProducts = farmerProducts;
        }
    }
}
