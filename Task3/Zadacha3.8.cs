// Задача 3: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 1 | 3 4
// 3 2 1 | 3 3
// _ _ _ | 1 1
// Результирующая матрица будет:
// 19 21
// 16 19

int EnterSmth(string request)
{
    System.Console.Write($" {request} >> ");
    int response = Convert.ToInt32(Console.ReadLine());
    return (response);
}

int EnterSize(string request)
{
    int response = 0;
    bool rightInput = false;
    while (rightInput == false)
    {
        response = EnterSmth($"{request} ");

        if (response > 0)
        {
            rightInput = true;
        }
        else { System.Console.WriteLine("Нужен хотя бы один элемент! Попробуйте еще раз."); }
    }
    return (response);
}

int[] EnterBorders()
{
    int[] borders = { 0, 0 };
    int min = 0;
    int max = 0;
    bool rightInput = false;
    while (rightInput == false)
    {
        System.Console.WriteLine(" Введите границы диапазона: ");
        min = EnterSmth("нижняя ");
        max = EnterSmth("верхняя ");

        if (max >= min)
        {
            borders[0] = min;
            borders[1] = max;
            rightInput = true;
        }
        else { System.Console.WriteLine("Все с ног на голову! Попробуйте еще раз."); }
    }
    return (borders);
}

int[,] RandMatrix(int ColumnsNum, int RowsNum, int Rmin, int Rmax)
{
    int[,] RandMatrix = new int[RowsNum, ColumnsNum];
    for (int i = 0; i < RowsNum; i++)
    {
        for (int j = 0; j < ColumnsNum; j++)
        {
            Random rnd = new Random();
            RandMatrix[i, j] = rnd.Next(Rmin, Rmax);
        }
    }
    return (RandMatrix);
}

int[,] GeneratedMatrix(string dataTitle)
{
    System.Console.WriteLine(dataTitle);

    int[] Borders = EnterBorders();
    int[,] Array = RandMatrix(EnterSize("Введите число столбцов"),
                   EnterSize("Введите число строк"), Borders[0], Borders[1]);
    return (Array);
}

void MatrixOutput(string resultTitle, int[,] Array)
{

    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine(resultTitle);

    for (int i = 0; i < Array.GetLength(0); i++)
    {
        Result = ("");
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Result = Result + Array[i, j] + "   ";
        }

        System.Console.WriteLine(Result);
    }
}

void MatrixMultiplication(int[,] firstMatrix, int[,] secondMatrix)
{
    if (firstMatrix.GetLength(1) == secondMatrix.GetLength(0))
    {
        int[,] multipliedMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

        for (int i = 0; i < multipliedMatrix.GetLength(0); i++)
        {
            for (int k = 0; k < multipliedMatrix.GetLength(1); k++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                    multipliedMatrix[i, k] += firstMatrix[i, j] * secondMatrix[j, k];
            }
        }
        MatrixOutput("Результат умножения:", multipliedMatrix);
    }

    else System.Console.WriteLine("К сожалению, матрицы не совместимы. Перемножить их нельзя(");
}

System.Console.WriteLine("Умножение матриц. Ваще огонь!!!");
System.Console.WriteLine("Генерируем 2 матрицы:");
int[,] firstMatrix = GeneratedMatrix("Данные для первого множителя >>");
int[,] secondMatrix = GeneratedMatrix("Данные для второго множителя >>");

MatrixOutput("Первый множитель:", firstMatrix);
MatrixOutput("Второй множитель:", secondMatrix);
MatrixMultiplication(firstMatrix, secondMatrix);
