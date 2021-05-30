using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class ConsultantsBestSales
    {
        public long ConsultantId { get; set; }
        public String ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public long FrequentProductCode { get; set; }
        public String FrequentProductName { get; set; }
        public long FrequentProductCount { get; set; }
        public long ProfitableProductCode { get; set; }
        public String ProfitableProductName { get; set; }
        public long ProfitableProductCount { get; set; }
    }
}
