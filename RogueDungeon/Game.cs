namespace RogueDungeon;

public class Game
{
    private readonly Parser _parser;

    // GameWorld gw = new GameWorld();
    private readonly Player _player;
    private bool _playing;

    public Game()
    {
        _playing = false;
        _parser = new Parser(new CommandWords());
        _player = new Player(GameWorld.Instance.Entrance);
    }

    /**
     * Main play routine.  Loops until end of play.
     */
    public void Play()
    {
        // Enter the main command loop.  Here we repeatedly read commands and
        // execute them until the game is over.

        var finished = false;
        while (!finished)
        {
            Console.Write("\n>");
            var command = _parser.ParseCommand(Console.ReadLine());
            if (command == null)
                Console.WriteLine("I don't understand...");
            else
                finished = command.Execute(_player);
        }
    }


    public void Start()
    {
        _playing = true;
        _player.OutputMessage(Welcome());
    }

    public void End()
    {
        _playing = false;
        _player.OutputMessage(Goodbye());
    }

    public string Welcome()
    {
        return
            "Welcome to the World of CSU!\n\n The World of CSU is a new, incredibly boring adventure game.\n\nType 'help' if you need help." +
            _player.CurrentRoom.Description();
    }

    public string Goodbye()
    {
        return "\nThank you for playing, Goodbye. \n";
    }
}