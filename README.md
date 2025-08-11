# Module 10 — C# Final Project: Contractor & Subcontractor Console App

## 📌 About the Project
This is the final project for Module 10 in C#.  
It’s a functional console application that manages subcontractor records and calculates their pay. The goal was to apply object-oriented programming principles like **classes, inheritance, constructors, methods, and properties** while keeping the program simple and easy to use.

The app simulates a subcontractor management tool:
- Tracks contractor details: name, ID number, start date, shift, and hourly pay rate.
- Automatically adds a **3% pay differential** for night shift workers.
- Runs entirely in the console with a clear, menu-driven interface.

---

## ✨ Features
- Add unlimited subcontractor records
- Track:
  - Contractor name
  - Contractor number
  - Start date
  - Shift (Day or Night)
  - Hourly pay rate
- Calculate pay for:
  - A single subcontractor
  - All subcontractors in the system
- Apply an **automatic 3% bonus** for night shift
- Validate user input to prevent errors

---

## 🗂 Project Structure
```plaintext
COP-FINAL/
├── Contractor.cs             # Base class: contractor info + ToString override
├── Subcontractor.cs          # Inherits from Contractor; adds shift, pay rate, ComputePay()
├── Program.cs                 # Main console UI, input handling, and program logic
├── README.md                  # Project documentation (this file)
