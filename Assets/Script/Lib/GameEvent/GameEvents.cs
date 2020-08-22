
public enum GameEventType
{
    PageChange
}


public struct GameEvent
{
    public GameEventType Type;
    public int Value;
    
    private static GameEvent e;

    public static void Trigger(GameEventType type, int value = 1)
    {
        e.Type  = type;
        e.Value = value;
        
        GameEventManager.TriggerGameEvent(e);
    }
}