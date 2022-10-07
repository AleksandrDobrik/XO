// See https://aka.ms/new-console-template for more information
Console.Clear();

int[,] pole = {
    { 0, 0, 0 },
    { 0, 0, 0 },
    { 0, 0, 0 }
};

void PrintArray (int[,] array)
{
    Console.WriteLine($"-------");
    for (int i = 0; i < array.GetLength(0); i ++)
        {
            
            for (int j = 0; j < array.GetLength(1); j ++)
            {
                if (array [i, j] == 0) Console.Write($"| ");
                if (array [i, j] == 1) Console.Write($"|X");
                if (array [i, j] == 4) Console.Write($"|O");
            }
            Console.Write($"|");
            Console.WriteLine();
            Console.WriteLine($"-------");
            
        }
        // Console.WriteLine();
}

int Examination (int[,] pole)
{
    for (int i = 0; i < 3; i++) // examination line
    {
        if (pole[i,0] == pole[i,1] && pole[i,1] == pole[i,2] && pole[i,0] == 4)
        {
        Console.WriteLine("Win player if O");
        return 1;
        }
        if (pole[i,0] == pole[i,1] && pole[i,1] == pole[i,2] && pole[i,0] == 1)
        {
        Console.WriteLine("Win player if X");
        return 1;
        }
    }

    for (int i = 0; i < 3; i++) // examination column
    {
        if (pole[0,i] == pole[1,i] && pole[1,i] == pole[2,i] && pole[1,i] == 4)
        {
        Console.WriteLine("Win player if O");
        return 1;
        }
        if (pole[0,i] == pole[1,i] && pole[1,i] == pole[2,i] && pole[1,i] == 1)
        {
        Console.WriteLine("Win player if X");
        return 1;
        }
    }

    if (pole[0, 0] + pole[1, 1] + pole[2, 2] == 12) // first dioganal
    {
        Console.WriteLine("Win player if O");
        return 1;
    }
    if (pole[0, 0] + pole[1, 1] + pole[2, 2] == 3)
    {
        Console.WriteLine("Win player if X");
        return 1;
    }
    
    if (pole[0, 2] + pole[1, 1] + pole[2, 0] == 12) // second dioganal
    {
        Console.WriteLine("Win player if O");
        return 1;
    } 
    if (pole[0, 2] + pole[1, 1] + pole[2, 0] == 3)
    {
        Console.WriteLine("Win player if X");
        return 1;
    }
    
    return 0;
}

int end = 0;
for (int i = 1; i < 10; i++)
{
    int  n = 0; int j = 0; 
    if ( i % 2 == 0)  
    {
        Console.WriteLine(" Player walks O ");
        PrintArray(pole);
        while(true)
        { 
        Console.SetCursorPosition(  n + 1, j + 2 );
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.LeftArrow && n > 0) n -= 2; 
        if (key == ConsoleKey.RightArrow && n < 4) n += 2;
        if (key == ConsoleKey.UpArrow && j > 0) j -= 2; 
        if (key == ConsoleKey.DownArrow && j < 4) j += 2;
        if (key == ConsoleKey.Spacebar && pole[j / 2, n / 2] ==0) 
        {
            pole[j / 2, n / 2] = 4;
            break;
        }
        if (key == ConsoleKey.Escape) end = 1; 
        }
        Console.Clear();
        if (end == 1) break;
        end = Examination(pole);
        if (end == 1) break;
    }
    else 
    {
        Console.WriteLine(" Player walks X ");
        PrintArray(pole);
        while(true)
        {
        Console.SetCursorPosition( n + 1, j + 2 );
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.LeftArrow && n > 0) n -= 2; 
        if (key == ConsoleKey.RightArrow && n < 4) n += 2;
        if (key == ConsoleKey.UpArrow && j > 0) j -= 2; 
        if (key == ConsoleKey.DownArrow && j < 4) j += 2;
        if (key == ConsoleKey.Spacebar && pole[j / 2, n / 2] ==0) 
        {
            pole[j / 2, n / 2 ] = 1;
            break;
        }
        if (key == ConsoleKey.Escape) end = 1; 
        }
        Console.Clear();   
        if (end == 1) break;
        end = Examination(pole);
        if (end == 1) break;
    }
}
Console.WriteLine("GAME OVER");

