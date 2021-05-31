using System;

namespace SalesManagementSystem.Models.CalculatedInformationModels
{
    public class SumOfConsultantSales
    {
        public long ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public long PersonalId { get; set; }
        public DateTime BirthDate { get; set; }
        public long SoldByConsultant { get; set; }
        public long SoldBySubConsultant { get; set; }
    }
}