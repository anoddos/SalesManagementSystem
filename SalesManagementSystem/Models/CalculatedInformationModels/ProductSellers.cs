using System;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class ProductSellers
    {
        public Consultant ConsultantId { get; set; }
        public String ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public long? ProductCode { get; set; }
        public long SalesCount { get; set; }
    }
}