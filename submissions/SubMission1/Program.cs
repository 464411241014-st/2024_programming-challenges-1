using System.Text;

namespace SubMission1;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ใส่เลขทีต้องการ");
        Console.WriteLine("ตัวอย่าง : [2, 3, 5, 7, 11], 10");
        string inputText = Console.ReadLine();
        inputText = inputText.Replace(" ", "").Replace("[", "");
        string[] splitText = inputText.Split("]");
        string[] numText = splitText[0].Split(",");
        string numberSumText = splitText[1].Remove(0, 1);
        int[] numberList = new int[numText.Length];
        for (int i = 0; i < numText.Length; i++)
        {
            numberList[i] = int.Parse(numText[i]);
        }
        int numberSumInt = Convert.ToInt32(numberSumText);
        List<int> numberPrime = new List<int>();
        // numberPrime.Add
        for (int i = 0; i < numberList.Length; i++)
        {
            if (numberList[i] == 0 || numberList[i] == 1)
                numberPrime.Add(numberList[i]);
            else
            {
                bool isPrime = true;
                for (int n = 2; n < numberList[i]; n++)
                {
                    if (numberList[i] % n == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    numberPrime.Add(numberList[i]);
                }
            }
        }
        bool isFirst = true;
        Console.Write("[");
        for (int i = 0; i < numberPrime.Count; i++)
        {
            for (int n = 0; n < numberPrime.Count; n++)
            {
                if (numberPrime[i] + numberPrime[n] == numberSumInt)
                {
                    if (!isFirst)
                    {
                        Console.Write(",");
                    }
                    Console.Write($"[{numberPrime[i]},{numberPrime[n]}]");
                    isFirst = false;
                }
            }
        }
        Console.Write("]");
    }
}