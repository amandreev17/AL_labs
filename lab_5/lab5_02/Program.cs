using System.Collections;

Mylist<int> mylist = new Mylist<int>(5);
Mylist<int> mylist2 = new Mylist<int> { 1, 2, 3, 4};
foreach(var t in mylist2)
{
    Console.WriteLine(t);
}
Console.WriteLine("");
mylist.Add(10);
mylist[0] = 1;
mylist[1] = 2;

for (int i = 0; i < mylist.Len; ++i)
{
    Console.WriteLine(mylist[i]);
}
int[] array = { 1, 2, 3 };
Mylist<int> mylist1 = new Mylist<int>(array);

for (int i = 0; i < mylist1.Len; ++i)
{
    Console.WriteLine(mylist1[i]);
}

class Mylist<T>: IEnumerable
{
    private T[] list;

    public Mylist(int count)
    {
        if (count < 0)
        {
            throw new Exception("Нельзя вводить отрицаиельные числа");
        }
        list = new T[count];
    }

    public Mylist(params T[] collection)
    {
        list = new T[collection.GetUpperBound(0) + 1];
        list = collection;
    }

    public void Add(T item)
    {
        int len = list.GetUpperBound(0) + 1;
        Mylist<T> l = new Mylist<T>(len + 1);
        for (int i = 0; i < len; ++i)
        {
            l.list[i] = list[i];
        }
        l.list[len] = item;
        list = l.list;
    }

    public T this[int index]
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

    public IEnumerator GetEnumerator()
    {
        return list.GetEnumerator();
    }
}