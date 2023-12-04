using System;
using System.IO;

class Program
{
    private static void randomNumberGeneration(string input, Random rnd, int[] nums, int temp)
    {
        for (int i = 0; i < temp; ++i)
        {
            for (int j = 0; j < nums.Length; ++j)
            {
                bool flag = true;
                int num = rnd.Next(1, 33);
                for (int l = 0; l < j; ++l)
                {
                    if (num == nums[l])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    nums[j] = num;
                }
                else
                {
                    --j;
                }
            }
            string row = string.Join(" ", nums);
            Console.WriteLine(row);

            using (StreamWriter writer = new StreamWriter(input, true))
            {
                File.AppendAllText(input, row + "\n");
            }
        }
    }

    static void Main()
    {
        string input = "input.txt";
        string output = "output.txt";
        Random rnd = new Random();
        int[] nums = new int[10];
        int temp = 1;
        randomNumberGeneration(input, rnd, nums, temp);

        using (StreamWriter writer = new StreamWriter(input, true))
        {
            Console.WriteLine("enter the number of lottery tickets: ");
            temp = int.Parse(Console.ReadLine());
            string n = Convert.ToString(temp);
            File.AppendAllText(input, n + "\n");
        }
        nums = new int[6];
        randomNumberGeneration(input, rnd, nums, temp);


        using (StreamReader reader = new StreamReader(input, true))
        {
            string row = reader.ReadLine();
            string[] rows = row.Split(" ");
            int[] numbers = new int[10];
            int[] ticets = new int[6];
            for (int i = 0; i < rows.Length; ++i)
            {
                numbers[i] = int.Parse(rows[i]);
            }
            reader.ReadLine();

            for (int i = 0; i < temp; ++i)
            {
                int count = 0;
                row = reader.ReadLine();
                rows = row.Split(" ");


                for (int h = 0; h < rows.Length; ++h)
                {
                    ticets[h] = int.Parse(rows[h]);
                }

                bool flag = false;

                for (int j = 0; j < numbers.Length; ++j)
                {

                    for (int l = 0; l < ticets.Length; ++l)
                    {
                        if (numbers[j] == ticets[l])
                        {
                            ++count;
                            break;
                        }
                    }

                    if (count >= 3)
                    {
                        flag = true;
                    }

                }
                if (flag == true)
                {
                    File.AppendAllText(output, "Lucky" + "\n");
                }
                else
                {
                    File.AppendAllText(output, "Unlucky" + "\n");
                }
            }

        }
        using (StreamReader reader = new StreamReader(output, true))
        {
            for (int i = 0; i < temp; ++i)
            {
                string result = reader.ReadLine();
                Console.WriteLine(result);
            }
        }
        Console.ReadKey();
        File.Delete(input);
        File.Delete(output);
    }
}