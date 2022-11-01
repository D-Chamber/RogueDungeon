namespace RogueDungeon;

public class Player
{
    public Player(Room room)
    {
        CurrentRoom = room;
    }

    public Room CurrentRoom { get; set; }

    public void WaltTo(string direction)
    {
        var nextRoom = CurrentRoom.GetExit(direction);
        if (nextRoom != null)
        {
            NotificationCenter.Instance.PostNotification(new Notification("PlayerWillEnterRoom", this));
            CurrentRoom = nextRoom;
            NotificationCenter.Instance.PostNotification(new Notification("PlayerDidEnterRoom", this));
            OutputMessage("\n" + CurrentRoom.Description());
        }
        else
        {
            OutputMessage("\nThere is no door on " + direction);
        }
    }

    public void OutputMessage(string message)
    {
        Console.WriteLine(message);
    }
}