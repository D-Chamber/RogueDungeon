namespace RogueDungeon;

public class QuitCommand : Command
{
    public QuitCommand()
    {
        Name = "quit";
    }

    override
        public bool Execute(Player player)
    {
        var answer = true;
        if (HasSecondWord())
        {
            player.OutputMessage("\nI cannot quit " + SecondWord);
            answer = false;
        }

        return answer;
    }
}