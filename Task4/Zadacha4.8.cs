// Задача 4. (*) Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


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

void MatrixNeatOutput(string resultTitle, int[,] Array)
{
    int size = Array.GetLength(0) * Array.GetLength(1);
    string digitNumber = size.ToString();

    string Result = ("");
    System.Console.WriteLine();
    System.Console.WriteLine(resultTitle);

    for (int i = 0; i < Array.GetLength(0); i++)
    {
        Result = ("");
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            string arrayItemNeat = ("");
            string arrayItem = arrayItemNeat + Array[i, j];

            for (int k = digitNumber.Length; k > arrayItem.Length; k--)
            { arrayItemNeat = arrayItemNeat + "0"; }

            arrayItemNeat = arrayItemNeat + arrayItem;
            Result = Result + arrayItemNeat + "   ";
        }
        System.Console.WriteLine(Result);
    }
}

int[,] SpiralFillMatrix(int columnsNum, int rowsNum)
{
    int[] direction = { 1, 0, -1, 0 }; 
    int[,] spiralFilledMatrix = new int[rowsNum, columnsNum];

    int currentCellX = 0;
    int currentCellY = 0;
    int fillerNumber = 1;
    int n = 0;
    int deltay = 0;
    int deltax = 1;
    int testCellX = currentCellX + deltax;
    int testCellY = currentCellY + deltay;

    spiralFilledMatrix[currentCellY, currentCellX] = fillerNumber;

    for (int i = 0; i < columnsNum * rowsNum - 1; i++)
    {
        bool cellTest = false;
        while (cellTest == false)
        {
            testCellX = currentCellX + deltax;
            testCellY = currentCellY + deltay;
            if ((testCellX <= columnsNum - 1) && (testCellX >= 0) && (testCellY <= rowsNum - 1) && (testCellY >= 0))
            {
                if (spiralFilledMatrix[testCellY, testCellX] == 0)
                { cellTest = true; }

                else
                {   n++;
                    n = n % 4;
                    deltay = deltax;
                    deltax = direction[n];
                }
            }
            else
            {
                n++;
                n = n % 4;
                deltay = deltax;
                deltax = direction[n];
            }
        }
        currentCellX = testCellX;
        currentCellY = testCellY;
        fillerNumber++;
        spiralFilledMatrix[currentCellY, currentCellX] = fillerNumber;
    }
    return(spiralFilledMatrix);
    }

MatrixNeatOutput("Торнадо!!! Вуаля!", SpiralFillMatrix(EnterSize("Число столбцов:"), EnterSize("Число строк:")));

