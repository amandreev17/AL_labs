MyMatrix myMatrix2 = new MyMatrix(2, 2, 1, 10);
myMatrix2.Print();
MyMatrix myMatrix3 = new MyMatrix(2, 2, 1, 10);
myMatrix3.Print();

MyMatrix myMatrix4 = myMatrix3 + myMatrix2;
myMatrix4.Print();

MyMatrix myMatrix5 = myMatrix2 * myMatrix3;
myMatrix5.Print();

MyMatrix myMatrix6 = myMatrix2 * 5;
myMatrix6.Print();

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

    public static MyMatrix operator +(MyMatrix myMatrix, MyMatrix myMatrix1)
    {
        int m = myMatrix.matrix.GetUpperBound(0) + 1;
        int n = myMatrix.matrix.GetUpperBound(1) + 1;
        if (m != myMatrix1.matrix.GetUpperBound(0) + 1 || n != myMatrix1.matrix.GetUpperBound(1) + 1)
        {
            Console.WriteLine("Данные матрицы нельзя складывать");
            System.Environment.Exit(0);
        }

        MyMatrix matrixSum = new MyMatrix(m, n, 0, 0);
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                matrixSum.matrix[i, j] = myMatrix.matrix[i, j] + myMatrix1.matrix[i, j];
            }
        }

        return matrixSum;
    }

    public static MyMatrix operator *(MyMatrix myMatrix, MyMatrix myMatrix1)
    {
        int m = myMatrix.matrix.GetUpperBound(0) + 1;
        int n = myMatrix1.matrix.GetUpperBound(1) + 1;
        if (m != n)
        {
            Console.WriteLine("Данные матрицы нельзя умножать");
            System.Environment.Exit(0);
        }

        MyMatrix matrixSum = new MyMatrix(m, n, 0, 1);
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                int s = 0;
                for (int k = 0; k < n; ++k)
                {
                    s += myMatrix.matrix[i, k] * myMatrix1.matrix[k, j];
                }
                matrixSum.matrix[i, j] = s;
            }
        }

        return matrixSum;
    }

    public static MyMatrix operator -(MyMatrix myMatrix, MyMatrix myMatrix1)
    {
        int m = myMatrix.matrix.GetUpperBound(0) + 1;
        int n = myMatrix.matrix.GetUpperBound(1) + 1;
        if (m != myMatrix1.matrix.GetUpperBound(0) + 1 || n != myMatrix1.matrix.GetUpperBound(1) + 1)
        {
            Console.WriteLine("Данные матрицы нельзя вычитать");
            System.Environment.Exit(0);
        }

        MyMatrix matrixSum = new MyMatrix(m, n, 0, 1);
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                matrixSum.matrix[i, j] = myMatrix.matrix[i, j] - myMatrix1.matrix[i, j];
            }
        }

        return matrixSum;
    }

    public static MyMatrix operator *(MyMatrix myMatrix, int d)
    {
        int m = myMatrix.matrix.GetUpperBound(0) + 1;
        int n = myMatrix.matrix.GetUpperBound(1) + 1;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                myMatrix.matrix[i, j] *= d;
            }
        }

        return myMatrix;
    }

    public static MyMatrix operator /(MyMatrix myMatrix, int d)
    {
        int m = myMatrix.matrix.GetUpperBound(0) + 1;
        int n = myMatrix.matrix.GetUpperBound(1) + 1;
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                myMatrix.matrix[i, j] /= d;
            }
        }

        return myMatrix;
    }

    public int this[int m, int n]
    {
        get => matrix[m, n];
    }

    public void Print()
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
}

