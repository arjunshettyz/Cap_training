using System.Collections;
class Arrays
{
    public static void ArrayExample()
    {
        // int[] num;
        int[] numbers = new int[5];
        int[] arr = {10, 20, 30, 40};
        

        // foreach(int x in arr)
        // {
        //     Console.Write(x+" ");
        // }

        int[ , ] matrix = new int[2,3];
        int[,] matrix2 =
        {
            {1, 2, 5},
            {3, 4, 6}
        } ;

        // foreach(int row in matrix2)
        // {
        //     Console.Write(row + " ");
        // }

        // for(int i=0; i<matrix2.GetLength(0); i++)
        // {
        //     for(int j=0; j<matrix2.GetLength(1); j++)
        //     {
        //         Console.Write(matrix2[i, j] + " ");
        //     }
        //     Console.WriteLine();
        // }



        // Jagged Array

        // int[][] jagged = new int[2][];

        // jagged[0] = new int[]{1, 2};
        // jagged[1] = new int[]{1, 2, 3, 4, 5};

        // foreach(int[]row in jagged)
        // {
        //     foreach(int nums in row)
        //     {
        //         Console.Write(nums+ " ");
        //     }
        //     Console.WriteLine();
        // }


        int[] arr2 = { 10, 20, 30, 40, 50, 3, 2};

        // foreach(int x in arr2)
        // {
        //     Console.Write(x+" ");
        // }
        // Console.WriteLine();
        

        Array.Clear(arr2, 2, 3);

        // foreach (int x in arr2)
        // {
        //     Console.Write(x + " ");
        // }

        Console.WriteLine();

        int[] src = {1, 2, 3};
        int[] dest = new int[3];

        // Array.Copy(src, dest, 3);
        // foreach (int x in dest)
        // {
        //     Console.Write(x + " ");
        // }

        Console.WriteLine();
        Array.Copy(src, dest, 2);

        // foreach (int x in dest)
        // {
        //     Console.Write(x + " ");
        // }

        int[] nums = {2, 9, 3};
        // Array.Resize(ref nums, 4);
        // Array.Resize(nums, 4);      // it will give error because "ref" is mandatory 

        // foreach (int x in nums)
        // {
        //     Console.Write(x + " ");
        // }

        // bool found = Array.Exists(nums, x => x > 25);

        // Console.WriteLine(found);


        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        ArrayList arrayList = new ArrayList();
        arrayList.Add(9);
        arrayList.Add(8);
        arrayList.Add(7);
        arrayList.Add("Aryan");
        arrayList.Add('A');
        arrayList.Add(12.92);

        // foreach(int n in list)
        // {
        //     Console.Write(n+ " ");
            
        // }
        Console.WriteLine();

        // foreach(var n in arrayList)
        // {
        //     Console.Write(n+ " ");
            
        // }

        Hashtable ht = new Hashtable();
        ht.Add(1, "Admin");
        ht.Add(2, "Aryan");
        ht.Add(3, 'A');
        ht.Add(4.345, 12.99);
        ht.Add("4a", "99");

        Console.WriteLine("HashTable Non-Generic Example----");
        // Console.WriteLine(ht[1]);

        // foreach(var ch in ht){
        //     Console.Write(ch + " ");
        // }

        Stack st = new Stack();
        st.Push(12);
        st.Push("aryan");
        st.Push('A');

        Console.WriteLine("Stack Non-Generic Example----");
        Console.WriteLine(st.Pop());
        Console.WriteLine(st.Pop());
        Console.WriteLine(st.Pop());

        Console.WriteLine("Queue Non-Generic Example----");

        Queue que = new Queue();
        que.Enqueue(10);
        que.Enqueue("Aryan");
        que.Enqueue('A');

        Console.WriteLine(que.Dequeue());
        Console.WriteLine(que.Dequeue());
        Console.WriteLine(que.Dequeue());

        Stack<int> stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        Console.WriteLine("Stack Generic Example---");
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        Console.WriteLine("Queue Generic Example---");
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());

        HashSet<int> set = new HashSet<int>();
        set.Add(1);
        set.Add(2);
        set.Add(1);

        Console.WriteLine("HashSet Generic Example----");
        foreach(int n in set)
        {
            Console.Write(n + " ");
        }
        

        SortedList<string, string> sortedList = new SortedList<string, string>();
        sortedList.Add("b", "B");
        sortedList.Add("a", "A");

        Console.WriteLine();
        Console.WriteLine("Sorted List Generic Example----");

        foreach(var ch in sortedList)
        {
            Console.WriteLine(ch + " ");
            Console.WriteLine(ch.Key + " " + ch.Value);
        }
        Console.WriteLine(sortedList.GetValueAtIndex(0)+ " ");


        Console.WriteLine("Dictionary Generic Example");
        Dictionary<int, string> employee = new Dictionary<int, string>();
        employee.Add(101, "Aryan");
        employee.Add(102, "Ritik");
        employee.Add(103, "Mahi");

        foreach(KeyValuePair<int, string> emp in employee)
        {
            Console.WriteLine(emp.Key + " - " + emp.Value);
        }



    }
}