public class Player
{
    public string playerName;
    public int highScore;
    public int totalScore;
    public float timeSpent;
    public int numberOfGames;
    public int level;
    public int coins;
    public int highestTower;
    public bool isTutorialSeen;

    public Player(string playerName, int highScore, int totalScore, float timeSpent, int numberOfGames, int level, int coins, int highestTower)
    {
        this.playerName = playerName;
        this.highScore = highScore;
        this.totalScore = totalScore;
        this.timeSpent = timeSpent;
        this.numberOfGames = numberOfGames;
        this.level = level;
        this.coins = coins;
        this.highestTower = highestTower;
    }
}
