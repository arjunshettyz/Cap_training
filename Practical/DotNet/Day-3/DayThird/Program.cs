// See https://aka.ms/new-console-template for more information
Console.WriteLine("Day 3 Practical");

// BankAccount acc1 = new BankAccount();
// acc1.AccountNumber = 101;
// acc1.Balance = 5000;
// acc1.Deposit(5000);

// Console.WriteLine("Account Number: " + acc1.AccountNumber);
// Console.WriteLine("Account Balance: " + acc1.Balance);

// Employee emp1 = new Employee();
// emp1.name = "Aryan";
// emp1.Salary = 1200000;
// emp1.Display();

// Wallet wallet1 = new Wallet();
// wallet1.AddMoney(5000);
// double balance = wallet1.GetBalance();
// Console.WriteLine("Account balance: "+ balance);

// MathOps math = new MathOps();
// Console.WriteLine("Addition of 3 and 4 is: " + math.Add(3, 4));
// Console.WriteLine("Addition of 4, 4 and 4 is: " + MathOps.Add(4, 4, 4));
// Console.WriteLine("Addition of 3.5 and 4.56 is: " + math.Add(3.5, 4.56));

// Console.WriteLine("Addition of 1 and 2 is: " + math.Add(1, 2));
// Console.WriteLine("Addition of 1.1 and 2 is: " + math.Add(1.1, 2));
// Console.WriteLine("Addition of 1.1 and 2.2 is: " + math.Add(1.1, 2.2));


// Person per1 = new Person();
// per1.person("Aryan", 22, "Muzz", 'M');
// per1.person("Aryan", 22, "Muzz");
// per1.person("Aryan", 22, "Muzz");
// per1.person(name:"Mohit", age:23, city:"Patna");

// for Each Example
// Practice.forEachEample("Aryan");
// Practice.sum(1,2,3,4);
// Practice.sum(1,2,3,4,5);
// Practice.sum(1,2,3,4,5,6,7);


// Reference Example
// int x = 20;
// Console.WriteLine("Before : " + x);
// Practice.decreaseByTen(ref x);
// Console.WriteLine("After : " + x);

// Out keyword Example
// int q = 0, r = 0;
// Practice.Divide(10, 3, out q, out r);
// Console.WriteLine("Quotient = " + q);
// Console.WriteLine("Remainder = " + r);

// string result;
// Practice.GetResult(75, out result);
// Console.WriteLine(result);


// int x = 50;
// Practice.Show(in x);

// Practice.DefaultThenParams(12, 1,2,3,4);

// this method give error because "param" needs to be at last
// Practice.ParamsThenDefault(12, 1,2,3,4,5);

// int[] arr = {1,2,3,4};
// Practice.ParamsArray(arr);
// Practice.ParamsArray({1,2,3,4});


// Local Method Example
// Practice.Process();
// Calculator.calculate();

// LambdaFunction.Example();


Console.WriteLine("Day 3 Assignment");
Console.WriteLine("Welcome to Banking Services!");
Console.Write("Enter Account Number: ");
int accountNumber;
while(!int.TryParse(Console.ReadLine(), out accountNumber))
{
    Console.Write("Invalid Account Number, Please Enter Correct Account Number: ");
}

Console.WriteLine("Enter Initial Balance: ");
double initialBalance;
while(!double.TryParse(Console.ReadLine(), out initialBalance))
{
    Console.Write("Invalid input!, Enter Valid Balance: ");
}

BankAccount account1 = new BankAccount(accountNumber, initialBalance);

int choice = 0;
while(choice != 4)
{
    Console.WriteLine("Choose: \n1. Deposit. \n2. Withdraw. \n3.Display Details. \n4. Exit");
    Console.Write("Choice: ");
    while(!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.Write("Invalid Input!, Enter Valid choice: ");
    }

    switch (choice)
    {
        case 1:
            {
                Console.Write("Enter Deposit Amount: ");
                double depositAmount;
                if(double.TryParse(Console.ReadLine(), out depositAmount))
                {
                    account1.Deposit(depositAmount);
                }
                else
                {
                    Console.WriteLine("Invalid Deposit Amount!");
                }
                break;
            }
        case 2:
            {
                Console.Write("Enter Withdraw Amount: ");
                double withdrawAmount;
                if(double.TryParse(Console.ReadLine(), out withdrawAmount))
                {
                    if(account1.Withdraw(withdrawAmount, out string msg))
                    {
                        Console.WriteLine(msg);
                    }
                    else
                    {
                        Console.WriteLine(msg);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Withdraw Amount!");
                }
                break;
            }
        case 3:
            {
                account1.Display();
                break;
            }
        case 4:
            {
                break;
            }
    }
}
