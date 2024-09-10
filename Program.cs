internal class Program
{
    static readonly List<String> AllValidChannels = new List<string> { "BE", "FE", "QA", "Urgent" };
    private static void Main(string[] args)
    {
        List<String> selectedChannels = new List<string>();

        while (true)
        {
            Console.Write("Input The recieve channel one by one(BE,FE,...etc.) or type done to finished : ");
            string inputChannel = Console.ReadLine();

            if (inputChannel == "done") break;
            selectedChannels.Add(inputChannel.ToUpper());
        }
        Console.Write("What happen to the channel : ");
        string statusMessage = Console.ReadLine();
        string formattedChannel = FormatChannel(selectedChannels);
        string result = GenerateFullNotificationTitle(formattedChannel, statusMessage);
        Console.WriteLine($"Right Formatted input title : {result}");

        List<string> allRecieveChannel = FilterValidRecieveChannel(selectedChannels);
        if (allRecieveChannel.Any())
        {
            Console.WriteLine($"Recieve Channel : {string.Join(", ", allRecieveChannel)}");
        }
    }
    static string GenerateFullNotificationTitle (string formattedChannel , string statusMessage)
    {
        return formattedChannel + " there is " + statusMessage ;
    }
    static string FormatChannel(List<String> selectedChannels)
    {
        return "[" + string.Join("][", selectedChannels) + "]";
    }
    static List<string> FilterValidRecieveChannel(List<String> selectedChannels)
    {
        return selectedChannels.Where(channel => AllValidChannels.Contains(channel)).ToList();
    }
}