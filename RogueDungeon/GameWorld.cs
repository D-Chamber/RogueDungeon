namespace RogueDungeon;

public class GameWorld
{
    private static GameWorld _instance;

    private Room _exit;

    private GameWorld()
    {
        CreateWorld();
        NotificationCenter.Instance.AddObserver("PlayerDidEnterRoom", PlayerDidEnterRoom);
        NotificationCenter.Instance.AddObserver("PlayerWillEnterRoom", PlayerWillEnterRoom);
    }

    public static GameWorld Instance
    {
        get
        {
            if (_instance == null) _instance = new GameWorld();
            return _instance;
        }
    }

    public Room Entrance { get; private set; }

    public Room Exit => Exit;

    public void PlayerDidEnterRoom(Notification notification)
    {
        var player = (Player)notification.Object;
        if (player != null) player.OutputMessage($"The player is {player.CurrentRoom.Tag}.");
    }

    public void PlayerWillEnterRoom(Notification notification)
    {
        var player = (Player)notification.Object;
        if (player != null) player.OutputMessage($"The player is about to leave {player.CurrentRoom.Tag}");
    }

    private void CreateWorld()
    {
        var outside = new Room("outside the main entrance of the university");
        var scctparking = new Room("in the parking lot at SCCT");
        var boulevard = new Room("on the boulevard");
        var universityParking = new Room("in the parking lot at University Hall");
        var parkingDeck = new Room("in the parking deck");
        var scct = new Room("in the SCCT building");
        var theGreen = new Room("in the green in from of Schuster Center");
        var universityHall = new Room("in University Hall");
        var schuster = new Room("in the Schuster Center");

        outside.SetExit("west", boulevard);

        boulevard.SetExit("east", outside);
        boulevard.SetExit("south", scctparking);
        boulevard.SetExit("west", theGreen);
        boulevard.SetExit("north", universityParking);

        scctparking.SetExit("west", scct);
        scctparking.SetExit("north", boulevard);

        scct.SetExit("east", scctparking);
        scct.SetExit("north", schuster);

        schuster.SetExit("south", scct);
        schuster.SetExit("north", universityHall);
        schuster.SetExit("east", theGreen);

        theGreen.SetExit("west", schuster);
        theGreen.SetExit("east", boulevard);

        universityHall.SetExit("south", schuster);
        universityHall.SetExit("east", universityParking);

        universityParking.SetExit("south", boulevard);
        universityParking.SetExit("west", universityHall);
        universityParking.SetExit("north", parkingDeck);

        parkingDeck.SetExit("south", universityParking);

        // assign special rooms
        Entrance = outside;
        _exit = universityHall;
    }
}