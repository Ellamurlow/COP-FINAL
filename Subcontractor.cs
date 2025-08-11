using System;

namespace ContractorProject
{
    public class Subcontractor : Contractor
    {
        // Shift: 1 = day, 2 = night
        public int Shift { get; set; }
        public double HourlyPayRate { get; set; }

        // Default constructor
        public Subcontractor() : base()
        {
            Shift = 1;
            HourlyPayRate = 0.0;
        }

        // Constructor that calls base
        public Subcontractor(string name, int number, DateTime startDate, int shift, double hourlyRate)
            : base(name, number, startDate)
        {
            Shift = shift;
            HourlyPayRate = hourlyRate;
        }

        // Compute pay: returns float, applies 3% differential for night shift (shift == 2)
        public float ComputePay(int hoursWorked)
        {
            double basePay = HourlyPayRate * hoursWorked;
            if (Shift == 2)
            {
                basePay *= 1.03; // 3% shift differential
            }
            return (float)basePay;
        }

        public override string ToString()
        {
            string shiftName = Shift == 1 ? "Day" : (Shift == 2 ? "Night" : $"Unknown({Shift})");
            return $"{base.ToString()}, Shift: {shiftName}, Rate: {HourlyPayRate:C}";
        }
    }
}
