namespace gb;

class Program
{
    public static void Main()
    {
        var field = new Field(
            Convert.ToInt32(Console.ReadLine()),
            Convert.ToInt32(Console.ReadLine())
        );

        field.Fill(' ');

        var waitHandler1 = new AutoResetEvent(false);
        var waitHandler2 = new AutoResetEvent(false);
        
        var fieldWorker1 = new FieldWorker(waitHandler1, field);
        var fieldWorker2 = new FieldWorker(waitHandler2, field);
        
        ThreadPool.QueueUserWorkItem(Fermer1, fieldWorker1);
        ThreadPool.QueueUserWorkItem(Fermer2, fieldWorker2);

        waitHandler1.WaitOne();
        waitHandler2.WaitOne();
        
        field.Print();
    }

    private static void Fermer1(object? arg)
    {
        if (arg == null)
            return;
        
        var rnd = new Random();
        var fieldWorker = (FieldWorker) arg;
        var cells = fieldWorker.Field.Cells;
        
        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                lock (cells)
                {
                    // Если фермер видит, что участок поля уже засеян другим фермером, он идет дальше
                    if (cells[i, j] != ' ')
                        break;
                    
                    cells[i, j] = 'X';
                }
                
                Thread.Sleep(rnd.Next(10, 100));
            }
        }

        fieldWorker.AutoResetEvent.Set();
    }
    
    private static void Fermer2(object? arg)
    {
        if (arg == null)
            return;
        
        var rnd = new Random();
        var fieldWorker = (FieldWorker) arg;
        var cells = fieldWorker.Field.Cells;
        
        for (int i = cells.GetLength(1) - 1; i >= 0; i--)
        {
            for (int j = cells.GetLength(0) - 1; j >= 0; j--)
            {
                lock (cells)
                {
                    // Если фермер видит, что участок поля уже засеян другим фермером, он идет дальше
                    if (cells[j, i] != ' ')
                        break;
                    
                    cells[j, i] = 'O';
                }
                
                Thread.Sleep(rnd.Next(10, 100));
            }
        }
        
        fieldWorker.AutoResetEvent.Set();
    }
}