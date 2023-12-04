using System;
using System.IO;

class Program
{
  static int maxarea(int[] height)
  {
    int maxarea = 0;
    int left = 0;
    int right = height.Length - 1;

    while (left < right)
    {
      int area = Math.Min(height[left], height[right]) * (right - left);
      maxarea = Math.Max(maxarea, area);

      if (height[left] < height[right])
        ++left;
      else
        --right;
    }
    return maxarea;
  }

  public static void Main(string[] args)
  {
    string put = "heights.txt";

    Console.Write("Enter the number of lines: ");
    int numberOfLines = int.Parse(Console.ReadLine());

    int[] height = new int[numberOfLines];
    for (int j = 0; j < numberOfLines; ++j)
    {
      Console.Write("Enter the line height " + (j + 1) + ": ");
      height[j] = int.Parse(Console.ReadLine());
    }
    int maxArea = maxarea(height);

    string row = string.Join(" ", height);
    string results = row + Environment.NewLine + "Maximum container area: " + maxArea;

    File.WriteAllText(put, results);

    Console.WriteLine("The file has been successfully created and the data has been written to it.");
    Console.ReadKey();
    File.Delete(put);
  }
}