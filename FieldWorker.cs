namespace gb;

internal class FieldWorker
{
    internal AutoResetEvent AutoResetEvent { get; }
    internal Field Field { get; }

    internal FieldWorker(AutoResetEvent autoResetEvent, Field field)
    {
        AutoResetEvent = autoResetEvent;
        Field = field;
    }
}