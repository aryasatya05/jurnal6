// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Contracts;

internal class Program
{
    private static void Main(String[] args)
    {
        SayaTubeVideo video = new SayaTubeVideo("blalalalala");
        video.PrintVidioDetail();
        video.increasePlayCount(123);
        video.PrintVidioDetail();

        for(int i = 0;i < 100000000;)
        {
            video.increasePlayCount(i);
            i = i + 100000000;
        }
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadVideos;
    private String username;

    public SayaTubeUser(String username)
    {
        Random random = new Random(DateTime.Now.Minute);
        this.username = username;

    }

    public int GetTotalVideoPlayCount()
    {
        return new int();
    }

    public void addVideo(SayaTubeVideo video)
    {

    }

    public void PrintAllVideoPlayCount()
    {

    }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Contract.Requires(title.Length == 100 && title != null);

        this.title = title;
        this.playCount = 0;
        Random random = new Random();
        this.id = random.Next(100000);
    }

    public void increasePlayCount(int playCount)
    {
        Contract.Requires(playCount <= 100000);
        try
        {
            checked
            {
                this.playCount = this.playCount + playCount;
            }
        }
        catch(OverflowException overexcept)
        {
            Console.WriteLine("Penambahan playcount melebihi batas! " + overexcept);
        }
    }
    
    public void PrintVidioDetail()
    {
        Console.WriteLine("Judul video" + this.title + ",Jumlah diputar" + this.playCount + "id" + this.id);
    }
}



