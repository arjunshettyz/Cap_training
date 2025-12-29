class BankAccount
{
    public int accNo;
    public double balance;
    public BankAccount(int accNo, double balance)
    {
        this.accNo = accNo;
        this.balance = balance;
    }
    // static int num1;
    // static int num2;

    // static BankAccount()
    // {
    //     num1 = 101;
    //     num2 = 102;
    // }
}

class FixedDeposit : BankAccount
{
    int timePeriod;
    double fdAmount;
    double roi;

    FixedDeposit(int timePeriod, double fdAmount, double roi): base(101, 5000)
    {
        this.timePeriod = timePeriod;
        this.fdAmount = fdAmount;
        this.roi = roi;
    }

}