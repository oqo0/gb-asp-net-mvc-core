namespace gb;

internal class Field
{
    internal char[,] Cells;
    
    internal Field(int width, int height)
    {
        Cells = new char[width, height];
    }

    /// <summary>
    /// Fill Cells array with values
    /// </summary>
    /// <param name="symbol">Char to fill the array</param>
    internal void Fill(char symbol)
    {
        for (int i = 0; i < Cells.GetLength(0); i++)
            for (int j = 0; j < Cells.GetLength(1); j++)
                Cells[i, j] = symbol;
    }

    /// <summary>
    /// Print Cells values to console
    /// </summary>
    internal void Print()
    {
        Console.WriteLine("-------------------------------------");
        
        for (int i = 0; i < Cells.GetLength(0); i++, Console.WriteLine())
            for (int j = 0; j < Cells.GetLength(1); j++)
                Console.Write(Cells[i, j]);
        
        Console.WriteLine("-------------------------------------");
    }
}