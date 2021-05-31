using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class ConsultantsBestSales
    {
        public long ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public string FrequentProductCode { get; set; }
        public string FrequentProductName { get; set; }
        public long FrequentProductCount { get; set; }
        public string ProfitableProductCode { get; set; }
        public string ProfitableProductName { get; set; }
        public long ProfitableProductCount { get; set; }
    }
}
