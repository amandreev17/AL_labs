Vector v1 = new Vector(1, 2, 3);
Vector v2 = new Vector(3, 3, 3);

(v1 + v2).Print();
Console.WriteLine(v1 * v2);
v1 = v1 * 6;
v1.Print();
Console.WriteLine(v1 > v2);

struct Vector
{
    private int x;
    private int y;
    private int z;

    public Vector(int _x = 0, int _y = 0, int _z = 0)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }

    public static int operator *(Vector v1, Vector v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    public static Vector operator *(Vector v1, int scale)
    {
        return new Vector(v1.x * scale, v1.y * scale, v1.x * scale);
    }

    public static bool operator >(Vector v1, Vector v2)
    {
        return v1.x * v1.x + v1.y * v1.y + v1.z * v1.z > v2.x * v2.x + v2.y * v2.y + v2.z * v2.z;
    }

    public static bool operator <(Vector v1, Vector v2)
    {
        return v1.x * v1.x + v1.y * v1.y + v1.z * v1.z < v2.x * v2.x + v2.y * v2.y + v2.z * v2.z;
    }

    public void Print()
    {
        Console.WriteLine($"x: {x}, y: {y}, z: {z}");
    }
}