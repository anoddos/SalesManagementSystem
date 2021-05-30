using System;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class SalesOfConsultants
    {
        public long SaleId { get; set; }
        public DateTime TimeStamp { get; set; }
        public long ConsultantId { get; set; }
        public String ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public long TotalQuantity { get; set; }
        public Double TotalPrice { get; set; }
    }
}