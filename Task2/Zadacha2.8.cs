// Задача 2: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка


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

int[] AllRowSums(int[,] someArray)
{
    int[] allRowSums = new int[someArray.GetLength(0)];

    for (int i = 0; i < someArray.GetLength(0); i++)
    {
        int currentRowSum = someArray[i, 0];
        for (int j = 1; j < someArray.GetLength(1); j++)
            currentRowSum += someArray[i, j];

        allRowSums[i] = currentRowSum;
        //System.Console.WriteLine(currentRowSum);
        //Тестер для сумм
    }
    return (allRowSums);
}

int ArrayMin(int[] someArray)
{
    int curentrMin = someArray[0];

    for (int i = 1; i < someArray.Length; i++)
    {
        if (someArray[i] < curentrMin)
            curentrMin = someArray[i];
    }
    return (curentrMin);
}

void ShowElementPos(string resultTitle, int[] someArray, int element)
{
    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine(resultTitle);

    for (int i = 0; i < someArray.Length; i++)
    {
        if (someArray[i] == element)
            Result = Result + (i + 1) + ", ";
    }
    Result = Result.TrimEnd(',', ' ') + ".";
    System.Console.WriteLine(Result);
}



int[] taskArraySums = AllRowSums(GeneratedMatrix());
int minSum = ArrayMin(taskArraySums);
ShowElementPos(("Строки с минимальной суммой:"), taskArraySums, minSum);



