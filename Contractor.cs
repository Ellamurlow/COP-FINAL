using System;

namespace ContractorProject
{
    public class Contractor
    {
        // Backing fields (could be auto-properties; shown explicitly for clarity)
        public string ContractorName { get; set; }
        public int ContractorNumber { get; set; }
        public DateTime StartDate { get; set; }

        // Default constructor
        public Contractor()
        {
            ContractorName = string.Empty;
            ContractorNumber = 0;
            StartDate = DateTime.MinValue;
        }

        // Parameterized constructor
        public Contractor(string name, int number, DateTime startDate)
        {
            ContractorName = name;
            ContractorNumber = number;
            StartDate = startDate;
        }

        // Override ToString for easy printing
        public override string ToString()
        {
            return $"Name: {ContractorName}, Number: {ContractorNumber}, Start: {StartDate:d}";
        }
    }
}
