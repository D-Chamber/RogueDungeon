namespace RogueDungeon;

public abstract class Command
{
    public Command()
    {
        Name = "";
        SecondWord = null;
    }

    public string Name { get; set; }

    public string SecondWord { get; set; }

    public string ThirdWord { get; set; }

    public bool HasSecondWord()
    {
        return SecondWord != null;
    }

    public bool HasThirdWord()
    {
        return ThirdWord != null;
    }

    public abstract bool Execute(Player player);
}