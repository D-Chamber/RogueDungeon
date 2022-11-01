namespace RogueDungeon;

public class HelpCommand : Command
{
    private readonly CommandWords _words;

    public HelpCommand() : this(new CommandWords())
    {
    }

    // Designated Constructor
    public HelpCommand(CommandWords commands)
    {
        _words = commands;
        Name = "help";
    }

    override
        public bool Execute(Player player)
    {
        if (HasSecondWord())
            player.OutputMessage("\nI cannot help you with " + SecondWord);
        else
            player.OutputMessage(
                "\nYou are lost. You are alone. You wander around the university, \n\nYour available commands are " +
                _words.Description());
        return false;
    }
}