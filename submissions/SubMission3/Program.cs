namespace SubMission3;

class Program
{
    static int resultWeight = int.MaxValue;
    static List<Connecter> allConnecters = new List<Connecter>();
    static void Main(string[] args)
    {
        //อินพุต: [(1, 2, 1), (2, 3, 2), (1, 3, 4), (3, 4, 1)], จุดเริ่มต้น: 1, จุดสิ้นสุด: 4
        Console.WriteLine("กรุณนากรอกทีต้องการหา");
        Console.WriteLine("ตัวอย่าง : [(1, 2, 1), (2, 3, 2), (1, 3, 4), (3, 4, 1)] ");
        string positionText = Console.ReadLine();
        Console.WriteLine("กรุณนากรอกจุดเริ่มต้น");
        Console.WriteLine("ตัวอย่าง : 1");
        string starttext = Console.ReadLine();
        Console.WriteLine("กรุณนากรอกจุดจบ");
        Console.WriteLine("ตัวอย่าง : 4");
        string endtext = Console.ReadLine();
        // string positionText = "[(1, 2, 1), (2, 3, 2), (1, 3, 4), (3, 4, 1)]";
        // string starttext = "1";
        // string endtext = "4";
        int startnum = int.Parse(starttext);
        int endnum = int.Parse(endtext);
        positionText = positionText.Replace(" ", "").Replace("[", "").Replace("]", "").Replace("(", "");
        string[] positionArray = positionText.Split("),");

        for (int i = 0; i < positionArray.Length; i++)
        {
            positionArray[i] = positionArray[i].Replace(")", "");
            string[] spliteds = positionArray[i].Split(",");
            Connecter connecter = new Connecter();
            connecter.Edges = new int[2];
            connecter.Edges[0] = int.Parse(spliteds[0]);
            connecter.Edges[1] = int.Parse(spliteds[1]);
            connecter.Weight = int.Parse(spliteds[2]);
            allConnecters.Add(connecter);
        }
        for (int i = 0; i < allConnecters.Count; i++)
        {
            if (startnum == allConnecters[i].Edges[0] || startnum == allConnecters[i].Edges[1])
            {
                findPath(startnum, new List<int>(), 0, endnum);
            }
        }
        Console.WriteLine(resultWeight);

    }
    static void findPath(int edge, List<int> edges, int weight, int endEdge)
    {
        if (edge == endEdge && resultWeight > weight)
        {
            resultWeight = weight;
        }
        List<Connecter> connecters = new List<Connecter>();
        for (int i = 0; i < allConnecters.Count; i++)
        {
            bool isExist = false;
            for (int e = 0; e < edges.Count; e++)
            {
                if (edges[e] == allConnecters[i].Edges[0] || edges[e] == allConnecters[i].Edges[1])
                {
                    isExist = true;
                    break;
                }
            }
            if (!isExist && (edge == allConnecters[i].Edges[0] || edge == allConnecters[i].Edges[1]))
            {
                connecters.Add(allConnecters[i]);
            }
        }
        for (int i = 0; i < connecters.Count; i++)
        {
            List<int> temps = new List<int>();
            foreach (var item in edges)
            {
                temps.Add(item);
            }
            temps.Add(edge);
            if (edge == connecters[i].Edges[0])
            {
                findPath(connecters[i].Edges[1], temps, weight + connecters[i].Weight, endEdge);
            }
            else if (edge == connecters[i].Edges[1])
            {
                findPath(connecters[i].Edges[0], temps, weight + connecters[i].Weight, endEdge);
            }
        }

    }
}
class Connecter
{
    public int[] Edges { get; set; }
    public int Weight { get; set; }
}