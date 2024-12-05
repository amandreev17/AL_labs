MyMatrix m = new MyMatrix(3, 3, 1, 10);
m.Show();
m.Fill();
m.Show();
m.ChangeSize(2, 2);
m.Show();
m[0, 0] = 1;
m[1, 1] = 4;
m.Show();
m.ShowPartialy(1, 4);


class MyMatrix
{
    private int[,] matrix;

    public MyMatrix(int m, int n, int r1, int r2)
    {
        Random random = new Random();
        this.matrix = new int[m, n];
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                this.matrix[i, j] = random.Next(r1, r2 + 1);
            }
        }
    }

    public void Fill()
    {
        int m = matrix.GetUpperBound(0) + 1;
        int n = matrix.GetUpperBound(1) + 1;
        Random random = new Random();
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                this.matrix[i, j] = random.Next(100, 200);
            }
        }
    }

    public void ChangeSize(int m, int n)
    {
        MyMatrix matr = new MyMatrix(m, n, 100, 200);
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                matr.matrix[i, j] = matrix[i, j];
            }
        }
        this.matrix = matr.matrix;
    }

    public void ShowPartialy(int start, int end)
    {
        int x = 0;
        int y = 0;
        int m = matrix.GetUpperBound(0) + 1;
        int n = matrix.GetUpperBound(1) + 1;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (matrix[i, j] == start)
                {
                    x = i;
                    y = j;
                    break;
                }
            }
        }
        for (int i = x; i < m; ++i)
        {
            for (int j = y; j < n; ++j)
            {
                Console.WriteLine(matrix[i, j]);
                if (matrix[i, j] == end)
                {
                    break;
                }
            }
        }

    }

    public void Show()
    {
        int m = matrix.GetUpperBound(0) + 1;
        int n = matrix.GetUpperBound(1) + 1;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("");
    }

    public int this[int x, int y]
    {
        get => matrix[x, y];
        set => matrix[x, y] = value;
    }
}