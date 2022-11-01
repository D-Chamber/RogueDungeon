namespace RogueDungeon;

public class Room
{
    private readonly Dictionary<string, Room> _exits;

    public Room() : this("No Tag")
    {
    }

    // Designated Constructor
    public Room(string tag)
    {
        _exits = new Dictionary<string, Room>();
        Tag = tag;
    }

    public string Tag { get; set; }

    public void SetExit(string exitName, Room room)
    {
        _exits[exitName] = room;
    }

    public Room GetExit(string exitName)
    {
        Room room = null;
        _exits.TryGetValue(exitName, out room);
        return room;
    }

    public string GetExits()
    {
        var exitNames = "Exits: ";
        var keys = _exits.Keys;
        foreach (var exitName in keys) exitNames += " " + exitName;

        return exitNames;
    }

    public string Description()
    {
        return "You are " + Tag + ".\n *** " + GetExits();
    }
}