
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