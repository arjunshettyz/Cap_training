using System.Globalization;

class MergeArray
{
    public static void Merge()
    {
        int[] arr1 = { 1, 3, 5 };
        int[] arr2 = { 2, 4, 6 };

        int n = arr1.Length;
        int m = arr2.Length;

        int[] sortedArray = new int[n + m];

        int p = 0;
        int i = 0, j = 0;

        while(i < n && j < m)
        {
            if(arr1[i] > arr2[j])
            {
                sortedArray[p++] = arr2[j++];
            }
            else
            {
                sortedArray[p++] = arr1[i++];
            }
        }
        while(i < n)
        {
            sortedArray[p++] = arr1[i++];
        }
        while(j < m)
        {
            sortedArray[p++] = arr2[j++];
        }

        Console.Write("Merged Array: ");
        foreach(int num in sortedArray){
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}