class PatientBill
{
    public string BillId { get; set; }
    public string PatientName { get; set; }
    public bool HasInsurance { get; set; }
    public double ConsultationFee { get; set; }
    public double LabCharges { get; set; }
    public double MedicineCharges { get; set; }

    public double GrossAmount;
    public double DiscountAmount;
    public double FinalPayable;
    public static PatientBill? LastBill;
    public static bool HasLastBill;

    public bool RegisterMethod()
    {
        if (BillId == "" || BillId == null)
        {
            Console.WriteLine("Invalid Input, Bill Id is non-Empty!");
            return false;
        }
        if (ConsultationFee <= 0 && LabCharges < 0 && MedicineCharges < 0)
        {
            Console.WriteLine("Invalid Input, ConsultationFee, LabCharges and MedicineCharges Can't be in Negative!");
            return false;
        }

        GrossAmount = ConsultationFee + LabCharges + MedicineCharges;
        if (HasInsurance)
        {
            DiscountAmount = GrossAmount * 0.10;
        }
        else
        {
            DiscountAmount = 0.0;
        }

        FinalPayable = GrossAmount - DiscountAmount;
        return true;

    }

    public static void DisplayLastBill()
    {
        string flag = LastBill.HasInsurance ? "Yes" : "No";
        if (HasLastBill)
        {
            Console.WriteLine("------------- Last Bill ------------");
            Console.WriteLine("BillId: " + LastBill.BillId);
            Console.WriteLine("Patient: " + LastBill.PatientName);
            Console.WriteLine($"Insured: {flag}");
            Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
            Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
            Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
            Console.WriteLine("---------------------------------------");
        }
        else
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
        }
    }

}
