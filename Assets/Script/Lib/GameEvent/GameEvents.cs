
public enum GameEventType
{
    PageChange
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