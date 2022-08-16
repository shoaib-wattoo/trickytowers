public class Player
{
    public string playerName;
    public int highScore;
    public int totalScore;
    public float timeSpent;
    public int numberOfGames;

    public Player(string playerName, int highScore, int totalScore, float timeSpent, int numberOfGames)
    {
        this.playerName = playerName;
        this.highScore = highScore;
        this.totalScore = totalScore;
        this.timeSpent = timeSpent;
        this.numberOfGames = numberOfGames;
    }
}