namespace gb;

public class FormulaCounter
{
    public AutoResetEvent AutoResetEvent { get; }
    public float[] Array { get; set; }
    
    public FormulaCounter(AutoResetEvent autoResetEvent, float[] array)
    {
        AutoResetEvent = autoResetEvent;
        Array = array;
    }
}