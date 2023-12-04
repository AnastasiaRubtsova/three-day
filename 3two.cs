using System;
using System.IO;
using System.Collections.Generic;

class Program
{
      static void Main()
      {
          string put = "nums.txt";
          Random rnd = new Random();
          Console.WriteLine("Enter the number of numbers: ");
          int n =Convert.ToInt32(Console.ReadLine());
          int[] nums = new int[n];
          
          for (int i = 0; i < nums.Length; ++i)
          {
          nums[i] = rnd.Next(-100,100);
          }
          string row = string.Join(" ", nums);

          using(StreamWriter writer = new StreamWriter(put))
          {
             writer.WriteLine(row);
          }

        using(StreamReader reader = new StreamReader(put))
        {  
                string original = reader.ReadLine();
                Console.WriteLine("The numbers that were in the file originally in the file: " + "\n" + original);
        }
        List<int> even = new List<int>();

        foreach(int num in nums)
        {
          if (num % 2 == 0)
          {
            even.Add(num);
          }
        }
        string cow = string.Join(" ", even);

        using(StreamWriter writer = new StreamWriter(put))
        {
           writer.WriteLine(cow);
        }
        using(StreamReader reader = new StreamReader(put))
        {  
                string result = reader.ReadLine();
                Console.WriteLine("The even numbers that are left in the file: " + "\n" + result);
        }

        Console.ReadKey();
        File.Delete(put);
       
      }
  }