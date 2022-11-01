namespace RogueDungeon;

public class GoCommand : Command
{
    public GoCommand()
    {
        Name = "go";
    }

    override
        public bool Execute(Player player)
    {
        if (HasSecondWord())
            player.WaltTo(SecondWord);
        else
            player.OutputMessage("\nGo Where?");
        return false;
    }
}