namespace RogueDungeon;

public class CommandWords
{
    private static readonly Command[] commandArray = { new GoCommand(), new QuitCommand() };
    private readonly Dictionary<string, Command> commands;

    public CommandWords() : this(commandArray)
    {
    }

    // Designated Constructor
    public CommandWords(Command[] commandList)
    {
        commands = new Dictionary<string, Command>();
        foreach (var command in commandList) commands[command.Name] = command;
        Command help = new HelpCommand(this);
        commands[help.Name] = help;
    }

    public Command Get(string word)
    {
        Command command = null;
        commands.TryGetValue(word, out command);
        return command;
    }

    public string Description()
    {
        var commandNames = "";
        var keys = commands.Keys;
        foreach (var commandName in keys) commandNames += " " + commandName;
        return commandNames;
    }
}