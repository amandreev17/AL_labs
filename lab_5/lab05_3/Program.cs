MyDictionary<int, string> dic = new MyDictionary<int, string>(1);
var mike = new KeyValuePair<int, string>(56, "Mike");
var tom = new KeyValuePair<int, string>(6, "Tom");
dic[0] = mike;
dic.Add(tom);
Console.WriteLine(dic.Len);
foreach(KeyValuePair<int, string> k in dic)
{
    Console.WriteLine($"{k.Key} {k.Value}");
}

class MyDictionary<TKey, TValue>
{
    private KeyValuePair<TKey, TValue>[] list;

    public MyDictionary(int count)
    {
        if (count < 0)
        {
            throw new Exception("Нельзя вводить отрицаиельные числа");
        }
        list = new KeyValuePair<TKey, TValue>[count];
    }

    public MyDictionary(params KeyValuePair<TKey, TValue>[] collection)
    {
        list = new KeyValuePair<TKey, TValue>[collection.GetUpperBound(0) + 1];
        list = collection;
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        int len = list.GetUpperBound(0) + 1;
        MyDictionary<TKey, TValue> l = new MyDictionary<TKey, TValue>(len + 1);
        for (int i = 0; i < len; ++i)
        {
            l.list[i] = list[i];
        }
        l.list[len] = item;
        list = l.list;
    }

    public KeyValuePair<TKey, TValue> this[int index]
    {

        get
        {
            if (index < 0 || index >= Len)
            {
                throw new Exception("Нельзя вводить такой индекс");
            }
            return list[index];
        }
        set => list[index] = value;
    }

    public int Len
    {
        get => list.GetUpperBound(0) + 1;
    }


    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < Len; i++)
        {
            yield return list[i];
        }
    }

}