class Practice
{
    public static void DictPractice()
    {
        Console.WriteLine("Q.1 Find the frequency of elements in an array using a Dictionary");

        int[] arr = {1, 3, 5, 6, 7, 1, 3, 4, 5};

        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach(int num in arr)
        {
            if (!dict.ContainsKey(num))
            {
                dict.Add(num, 1);
            }
            else
            {
                dict[num] = dict[num] + 1;
                
            }
        }

        foreach(var num in dict)
        {
            Console.WriteLine(num.Key + " " + num.Value);
        }
    }
}