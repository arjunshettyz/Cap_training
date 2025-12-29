// See https://aka.ms/new-console-template for more information
using System;
class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to MediSure Clinic Application!");

        int choice = 0;

        while(choice != 4)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine(" 1. Create New Bill (Enter Patient Details). \n 2. View Last Bill. \n 3. Clear Last Bill. \n 4. Exit");
            Console.Write("Enter Your Option: ");
            while(!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid Input!");
            }

            switch (choice)
            {
                case 1:
                    {
                        Console.Write("Enter Bill Id: ");
                        string billId = Console.ReadLine();

                        Console.Write("Enter Patient Name: ");
                        string patientName = Console.ReadLine();

                        Console.Write("Is the patient insured? (Y/N):");
                        char ch = Convert.ToChar(Console.ReadLine());
                        ch = Char.ToLower(ch);
                        bool hasInsurance = ch == 'y'? true:false;

                        Console.Write("Enter Consultation Fee: ");
                        double consultationFee = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Lab Charges: ");
                        double labCharges = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Medicine Charges: ");
                        double medicineCharges = Convert.ToDouble(Console.ReadLine());

                        PatientBill patientBill = new PatientBill
                        {
                            BillId = billId,
                            PatientName = patientName,
                            HasInsurance = hasInsurance,
                            ConsultationFee = consultationFee,
                            LabCharges = labCharges,
                            MedicineCharges = medicineCharges

                        };
                        bool created = patientBill.RegisterMethod();

                        if (created)
                        {
                            PatientBill.HasLastBill = true;
                            PatientBill.LastBill = patientBill;
                            Console.WriteLine("Bill created successfully.");
                            Console.WriteLine("Bill Details: ");
                            Console.WriteLine($"Gross Amount:  {patientBill.GrossAmount:F2}");
                            Console.WriteLine("Discount Amount: "+ patientBill.DiscountAmount.ToString("F2"));
                            Console.WriteLine("Final Payable: "+ Math.Round(patientBill.FinalPayable, 2));
                            Console.WriteLine("-------------------------------------------------");

                        }
                        else
                        {
                            Console.WriteLine("Oops!, Something Went Wrong.");
                        }

                        break;
                    }
                case 2:
                    {
                        if (PatientBill.HasLastBill)
                        {
                            PatientBill.DisplayLastBill();
                        }
                        else
                        {
                            Console.WriteLine("No bill available. Please create a new bill first.");
                        }
                        break;
                    }
                case 3:
                    {
                        if(PatientBill.LastBill == null)
                        {
                            Console.WriteLine("No bill available. Please create a new bill first.");
                        }
                        PatientBill.LastBill = null;
                        PatientBill.HasLastBill = false;
                        Console.WriteLine("Last Bill cleared Successfully!");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;
                    }
            }
        }

    }
}
