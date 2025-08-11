using System;
using System.Collections.Generic;
using System.Globalization;

namespace ContractorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Subcontractor Manager ===");
            var subs = new List<Subcontractor>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Add a subcontractor");
                Console.WriteLine("2) List subcontractors");
                Console.WriteLine("3) Compute pay for a subcontractor");
                Console.WriteLine("4) Compute pay for all subcontractors (prompt hours each)");
                Console.WriteLine("5) Exit");

                Console.Write("Option: ");
                string opt = Console.ReadLine()?.Trim() ?? "";
                Console.WriteLine();

                if (opt == "1")
                {
                    var s = ReadSubcontractorFromUser();
                    subs.Add(s);
                    Console.WriteLine("Subcontractor added.");
                }
                else if (opt == "2")
                {
                    if (subs.Count == 0)
                    {
                        Console.WriteLine("No subcontractors entered yet.");
                    }
                    else
                    {
                        Console.WriteLine("Subcontractors:");
                        for (int i = 0; i < subs.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {subs[i]}");
                        }
                    }
                }
                else if (opt == "3")
                {
                    if (subs.Count == 0)
                    {
                        Console.WriteLine("No subcontractors available.");
                        continue;
                    }

                    int index = PromptForIndex(subs.Count, "Select subcontractor by number to compute pay: ");
                    if (index == -1) continue;

                    int hours = PromptForInt("Enter hours worked: ", min: 0);
                    float pay = subs[index].ComputePay(hours);
                    Console.WriteLine($"Pay for {subs[index].ContractorName} (hours {hours}): {pay:C}");
                }
                else if (opt == "4")
                {
                    if (subs.Count == 0)
                    {
                        Console.WriteLine("No subcontractors available.");
                        continue;
                    }

                    for (int i = 0; i < subs.Count; i++)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Subcontractor {i + 1}: {subs[i].ContractorName}");
                        int hours = PromptForInt("Enter hours worked: ", min: 0);
                        float pay = subs[i].ComputePay(hours);
                        Console.WriteLine($" -> Pay: {pay:C}");
                    }
                }
                else if (opt == "5")
                {
                    Console.WriteLine("Exiting. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Choose 1-5.");
                }
            }
        }

        static Subcontractor ReadSubcontractorFromUser()
        {
            Console.Write("Full name: ");
            string name = Console.ReadLine()?.Trim() ?? "";

            int number = PromptForInt("Contractor number (integer): ", min: 0);

            DateTime startDate;
            while (true)
            {
                Console.Write("Start date (YYYY-MM-DD): ");
                string input = Console.ReadLine()?.Trim() ?? "";
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                {
                    break;
                }
                Console.WriteLine("Invalid date format. Use YYYY-MM-DD, e.g. 2025-04-14");
            }

            int shift;
            while (true)
            {
                Console.Write("Shift (1 = day, 2 = night): ");
                string s = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(s, out shift) && (shift == 1 || shift == 2))
                    break;
                Console.WriteLine("Invalid shift. Enter 1 or 2.");
            }

            double rate;
            while (true)
            {
                Console.Write("Hourly pay rate (e.g., 18.50): ");
                string r = Console.ReadLine()?.Trim() ?? "";
                if (double.TryParse(r, out rate) && rate >= 0.0)
                    break;
                Console.WriteLine("Invalid rate. Enter a non-negative number.");
            }

            return new Subcontractor(name, number, startDate, shift, rate);
        }

        static int PromptForInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(s, out int val))
                {
                    if (val < min)
                    {
                        Console.WriteLine($"Value must be >= {min}.");
                        continue;
                    }
                    if (val > max)
                    {
                        Console.WriteLine($"Value must be <= {max}.");
                        continue;
                    }
                    return val;
                }
                Console.WriteLine("Invalid integer. Try again.");
            }
        }

        static int PromptForIndex(int count, string prompt)
        {
            Console.Write(prompt);
            string sel = Console.ReadLine()?.Trim() ?? "";
            if (!int.TryParse(sel, out int idx) || idx < 1 || idx > count)
            {
                Console.WriteLine("Invalid selection.");
                return -1;
            }
            return idx - 1;
        }
    }
}
