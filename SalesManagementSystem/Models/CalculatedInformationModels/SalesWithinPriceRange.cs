using System;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class SalesWithinPriceRange
    {
        public long SaleId { get; set; }
        public DateTime TimeStamp { get; set; }
        public long ConsultantId { get; set; }
        public String ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public long ProductCount { get; set; }
    }
}