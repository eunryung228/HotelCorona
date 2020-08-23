
public enum GameEventType
{
    DailyStart,
    Half,
    PageChange,
    DailyEnd,
}

public struct GameEvent
{
    public GameEventType Type;
    
    private static GameEvent e;

    public static void Trigger(GameEventType type)
    {
        e.Type  = type;

        GameEventManager.TriggerGameEvent(e);
    }
}

public enum PopupEventType
{
    Confirm,
    Cure,
    Escape
}

public struct PopupEvent
{
    public PopupEventType Type;

    public int Count;
    public int Index;

    private static PopupEvent e;

    public static void Trigger(PopupEventType type, int count = 0, int index = 0)
    {
        e.Type  = type;
        e.Count = count;
        e.Index = index;
        
        GameEventManager.TriggerGameEvent(e);
    }
}