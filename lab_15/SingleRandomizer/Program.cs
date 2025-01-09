SingleRandomizer rand1 = SingleRandomizer.getInstance();
SingleRandomizer rand2 = SingleRandomizer.getInstance();
Console.WriteLine(object.ReferenceEquals(rand1, rand2));

class SingleRandomizer
{
    private static SingleRandomizer? instance;
    public Random rand { get; private set; }
    private static object syncRoot = new Object();

    protected SingleRandomizer()
    {
        this.rand = new Random();
    }

    public static SingleRandomizer getInstance()
    {
        if (instance == null)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new SingleRandomizer();
            }
        }
        return instance;
    }

    public int getNumber()
    {
        lock(syncRoot)
        {
            return rand.Next(1, 101);
        }

    }
}