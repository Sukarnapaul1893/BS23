namespace Student_Management.Services;

public class UtilityService
{
    public void DisplayMessage(params string[] message)
    {
        foreach (var str in message) Console.WriteLine(str);
    }
    
    public void DisplayMessage(int message)
    {
        Console.WriteLine("{0}", message);
    }
    
    public string Input()
    {
        return Console.ReadLine();
    }
}