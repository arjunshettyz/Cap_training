// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main()
    {
        // Task -1, DYNAMIC PRODUCT PRICE ANALYSIS (ARRAYS)
        Console.WriteLine("Welcome to Enterprise Application!");
        Console.WriteLine("Task -1, DYNAMIC PRODUCT PRICE ANALYSIS (ARRAYS)");
        Console.Write("Enter number of products: ");
        
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter Product Price for Item {i+1}: ");
            int num = int.Parse(Console.ReadLine());
            if (num >= 0)
            {
                arr[i] = num;
            }
        }

        double avg = FindAveragePrice(arr, n);
        Console.WriteLine("Average Price: " + avg);

        Console.Write("Before Sorting: ");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Array.Sort(arr);
        Console.Write("After Sorting: ");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            if (arr[i] < avg)
            {
                arr[i] = 0;
            }
        }
        Console.Write("After Modification: ");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Array.Resize(ref arr, n + 5);
        for (int i = n; i < n + 5; i++)
        {
            arr[i] = (int)avg;

        }

        Console.Write("After Resizing: ");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Console.Write("Final Array: ");
        for (int i = 0; i < n + 5; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        // Task - 2, BRANCH SALES ANALYSIS (MULTI-DIMENSIONAL ARRAY)
        Console.WriteLine("Task - 2, BRANCH SALES ANALYSIS (MULTI-DIMENSIONAL ARRAY)");
        Console.Write("Enter No. of Branches: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Enter No. of Months: ");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[b, m];

        for (int i = 0; i < b; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        int highestSale = -1;
        for (int i = 0; i < b; i++)
        {
            int totalSale = 0;
            for (int j = 0; j < m; j++)
            {
                // Console.Write(matrix[i, j] + " ");
                totalSale += matrix[i, j];
                if (matrix[i, j] > highestSale)
                {
                    highestSale = matrix[i, j];
                }
            }
            Console.WriteLine($"Total Sales for {i + 1} Branch: {totalSale}");
        }
        Console.WriteLine("Global Highest Sale: " + highestSale);

        // TASK 3 – PERFORMANCE-BASED DATA EXTRACTION (JAGGED ARRAY)
        Console.WriteLine("TASK 3 - PERFORMANCE-BASED DATA EXTRACTION (JAGGED ARRAY)");
        
        int[][] jaggedArray = new int[b][];

        for(int i=0; i<b; i++)
        {
            List<int> temp = new List<int>();
            for(int j=0; j<m; j++)
            {
                if(matrix[i, j] >= avg)
                {
                    temp.Add(matrix[i, j]);
                }
            }
            jaggedArray[i] = temp.ToArray();
        }

        Console.WriteLine("Jagged Array Content: ");
        for(int i=0; i<jaggedArray.Length; i++)
        {
            for(int j=0; j<jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }

        // TASK 4 – CUSTOMER TRANSACTION CLEANING (LIST & HASHSET)
        Console.WriteLine("TASK 4 - CUSTOMER TRANSACTION CLEANING (LIST & HASHSET)");
        Console.WriteLine("Enter No. of Customer Transaction: ");
        int transactionNo = int.Parse(Console.ReadLine());

        List<int> list = new List<int>();
        for(int i=0; i<transactionNo; i++)
        {
            Console.Write($"Transaction {i + 1}: ");
            list.Add(int.Parse(Console.ReadLine()));
        }
        HashSet<int> hashSet = new HashSet<int>(list);
        List<int> cleanedList = hashSet.ToList();

        Console.Write("Original Customer Id List: ");
        foreach(int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        Console.Write("Cleaned Customer Id List: ");
        foreach(int num in cleanedList)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        int duplicate = list.Count - cleanedList.Count;
        Console.WriteLine("Duplicates Removed: " + duplicate);


        // Task - 5 FINANCIAL TRANSACTION FILTERING (DICTIONARY & SORTEDLIST)
        Console.WriteLine("Task - 5, FINANCIAL TRANSACTION FILTERING (DICTIONARY & SORTEDLIST)");
        Console.Write("Enter No. of Transaction: ");
        int noOfTransaction;
        while (!int.TryParse(Console.ReadLine(), out noOfTransaction) || noOfTransaction <= 0)
        {
            Console.WriteLine("Invalid Input, Please Enter Valid Transaction Number.");
        }

        Dictionary<int, double> dict = new Dictionary<int, double>();

        for(int i=0; i<noOfTransaction; i++)
        {
            Console.Write($"Enter {i+1} Transaction Id: ");
            
            if(!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Error: Invalid Id, Enter Valid and Positive Transaction Id..");
                i--;
                continue;
            }
            if (dict.ContainsKey(id))
            {
                Console.WriteLine($"Error: Transaction Id {id} Already Exists.");
                i--;
                continue;
            }
            
            Console.Write($"Enter {i+1} Transaction Amount: ");
            if (!int.TryParse(Console.ReadLine(), out int amount) || amount <= 0)
            {
                Console.WriteLine("Error: Invalid Amount, Enter Valid and Positive Amount..");
                i--;
                continue;
            }

            dict.Add(id, amount);
            
        }

        SortedList<int, double> sortedList = new SortedList<int, double>();

        foreach(var transaction in dict)
        {
            if(transaction.Value >= avg)
            {
                sortedList.Add(transaction.Key, transaction.Value);
            }
        }

        if(sortedList.Count == 0)
        {
            Console.WriteLine("No transactions met the filtering criteria.");
        }
        else
        {
            Console.WriteLine("Displaying sorted high-value transactions...");
            int p = 1;
            foreach(var num in sortedList)
            {
                Console.WriteLine($"Transaction {p++}: {num.Key} -  {num.Value}");
            }
        }
        Console.WriteLine("Task 5 Completed!");

        // Task - 6, PROCESS FLOW MANAGEMENT (STACK & QUEUE)
        Console.WriteLine("Task - 6, PROCESS FLOW MANAGEMENT (STACK & QUEUE)");
        Console.Write("Enter No. of Operations: ");
        int noOfOperation;
        while (!int.TryParse(Console.ReadLine(), out noOfOperation) || noOfOperation <= 0)
        {
            Console.WriteLine("Invalid Input, Please Enter Valid and Positive Operation Number.");
        }
        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();

        for(int i=0; i<noOfOperation; i++)
        {
            Console.Write($"Enter Description of Operation {i+1}: ");
            string description = Console.ReadLine();

            queue.Enqueue(description);
            stack.Push(description);
        }

        Console.WriteLine("Processing Operation: ");
        while(queue.Count > 0)
        {
            string op = queue.Dequeue();
            Console.WriteLine($"Processing: {op}");
        }
        Console.WriteLine("Undoing Last 2 Operations:");
        for(int i=0; i<2; i++)
        {
            if(stack.Count > 0)
            {
                Console.WriteLine($"Undoing: {stack.Pop()}");
            }
            else
            {
                Console.WriteLine("No more operations left to undo.");
            }
        }
        Console.WriteLine("Remaining Operations: ");
        if(stack.Count == 0)
        {
            Console.WriteLine("Empty Stack!");
        }
        else
        {
            foreach(string op in stack)
            {
                Console.WriteLine($"- {op}");
            }
        }
        Console.WriteLine("Task - 6 Completed!");

        // TASK 7 – LEGACY DATA RISK DEMONSTRATION (HASHTABLE & ARRAYLIST)
        Console.WriteLine("TASK 7 - LEGACY DATA RISK DEMONSTRATION (HASHTABLE & ARRAYLIST)");

        Console.Write("Enter No. of User: ");
        int noOfUser;
        while (!int.TryParse(Console.ReadLine(), out noOfUser) || noOfUser <= 0)
        {
            Console.WriteLine("Invalid Input, Please Enter Valid and Positive Number.");
        }

        Hashtable hstable = new Hashtable();
        ArrayList arrayList = new ArrayList();

        for(int i=0; i<noOfUser; i++)
        {
            Console.Write($"Enter Username {i+1}: ");
            string username = Console.ReadLine();

            Console.Write($"Enter user {username}'s Role: ");
            string role = Console.ReadLine();

            hstable.Add(username, role);

            arrayList.Add(username);
            arrayList.Add(role);
        }

        Console.WriteLine("HashTable Content - Key and Value Mapping: ");
        foreach(DictionaryEntry user in hstable)
        {
            Console.WriteLine($"User: {user.Key} and Role: {user.Value}");
        }

        Console.WriteLine("ArrayList Content - Mixed Data: ");
        arrayList.Add(123);
        arrayList.Add('A');

        foreach(var item in arrayList)
        {
            Console.WriteLine($"Item: {item} and Type: {item.GetType()}");
        }

        Console.WriteLine("Task 7 Completed!");

        Console.WriteLine("Thanks for using Enterprise System!");


    }
    public static double FindAveragePrice(int[] arr, int n)
    {
        double sum = 0, avg;

        foreach (int num in arr)
        {
            sum += num;
        }
        avg = sum / n;
        return avg;

    }


}