using System;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class ProductSellers
    {
        public long ConsultantId { get; set; }
        public String ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProductCode { get; set; }
        public long SalesCount { get; set; }
    }
}