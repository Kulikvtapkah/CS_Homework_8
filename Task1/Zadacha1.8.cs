// Задача 1: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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
    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine($"Случайная матрица {RowsNum}x{ColumnsNum}: ");

    for (int i = 0; i < RowsNum; i++)
    {
        Result = ("");
        for (int j = 0; j < ColumnsNum; j++)
        {
            Random rnd = new Random();

            RandMatrix[i, j] = rnd.Next(Rmin, Rmax);
            Result = Result + RandMatrix[i, j] + "   ";
        }

        System.Console.WriteLine(Result);
    }
    return (RandMatrix);
}

int[,] GeneratedMatrix()
{
    System.Console.WriteLine("Генерируем случайную матрицу. Поехали!");

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

int[,] RowSorting(int rowNum, int[,] arrayToSort)
{
    bool flag = true;
    int n = 1;

    while (arrayToSort.GetLength(1) - n > 0 && flag == true)
    {
        flag = false;
        for (int i = 0; i < arrayToSort.GetLength(1) - n; i++)
        {
            int box = arrayToSort[rowNum, i];
            if (arrayToSort[rowNum, i] < arrayToSort[rowNum, i + 1])
            {
                arrayToSort[rowNum, i] = arrayToSort[rowNum, i + 1];
                arrayToSort[rowNum, i + 1] = box;
                flag = true;
            }
        }
        n++;
    }
    return (arrayToSort);
}

int[,] AllRowsSorted(int[,] arrayToSort)
{
    for (int i = 0; i < arrayToSort.GetLength(0); i++)
        arrayToSort = RowSorting(i, arrayToSort);

    return (arrayToSort);
}



int[,] someMatrix = GeneratedMatrix();
MatrixOutput(("Элементы в строках отсортированы по убыванию:"), AllRowsSorted(someMatrix));


