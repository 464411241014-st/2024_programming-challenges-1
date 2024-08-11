namespace SubMission2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ใส่ข้อความที่ต้องการหา Pangram");
        Console.WriteLine("ตัวอย่าง : The quick brown fox jumps over the lazy dog ");
        string keywordinput = Console.ReadLine();
        string[] keywordListword = keywordinput.Split(" ");
        keywordinput = keywordinput.ToLower();
        keywordinput = keywordinput.Replace(" ", "").Replace(".", "");
        char[] keywordList = keywordinput.ToArray();
        char ch = 'a';
        bool isPangram = false;
        while (ch <= 'z')
        {
            isPangram = false;
            for (int i = 0; i < keywordList.Length; i++)
            {
                if (keywordList[i] == ch)
                {
                    isPangram = true;
                    break;
                }

            }
            if (!isPangram)
            {
                break;
            }
            ch++;
        }
        if (isPangram)
        {
            string longestWord = string.Empty;
            foreach (var item in keywordListword)
            {
                if (longestWord.Length <= item.Length)
                {
                    longestWord = item;
                }
            }
            Console.WriteLine(longestWord);
        }
        else
        {
            Console.WriteLine("Not a Pangram");
        }
    }
}
