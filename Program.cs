namespace gb;

class Program
{
    public static void Main()
    {
        DateTime start = DateTime.Now;
        Task1();
        DateTime finish = DateTime.Now;
        Console.WriteLine($"[Task1] Инициализация массива заняла у нас:  {finish - start} сек.");
        
        start = DateTime.Now;
        Task2();
        finish = DateTime.Now;
        Console.WriteLine($"[Task2] Инициализация массива заняла у нас:  {finish - start} сек.");
    }

    static void Task1()
    {
        AutoResetEvent waitHandler = new AutoResetEvent(false);
        
        var formulaCounter = new FormulaCounter(
            waitHandler,
            Enumerable.Repeat(1f, 1_000_000).ToArray()
        );
        
        Thread thread = new Thread(ApplyFormula);
        
        thread.Start(formulaCounter);

        waitHandler.WaitOne();
    }
    
    static void Task2()
    {
        AutoResetEvent waitHandler1 = new AutoResetEvent(false);
        AutoResetEvent waitHandler2 = new AutoResetEvent(false);
        
        var formulaCounter1 = new FormulaCounter(
            waitHandler1,
            Enumerable.Repeat(1f, 500_000).ToArray()
        );
        var formulaCounter2 = new FormulaCounter(
            waitHandler2,
            Enumerable.Repeat(1f, 500_000).ToArray()
        );
        
        Thread thread1 = new Thread(ApplyFormula);
        Thread thread2 = new Thread(ApplyFormula);
        
        thread1.Start(formulaCounter1);
        thread2.Start(formulaCounter2);

        waitHandler1.WaitOne();
        waitHandler2.WaitOne();
    }

    static void ApplyFormula(object? parameter)
    {
        if (parameter == null)
            return;

        var formulaCounter = (FormulaCounter) parameter;
        var array = formulaCounter.Array;

        var res = array.Select(
            (x, i) =>
                (float)
                (x * Math.Sin(0.2f + i / 5) *
                 Math.Cos(0.2f + i / 5) *
                 Math.Cos(0.4f + i / 2))
        );

        formulaCounter.AutoResetEvent.Set();
    }
}