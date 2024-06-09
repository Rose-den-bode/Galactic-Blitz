[System.Serializable]

public class SaveObject
{
    public int coins;
    public int highscore;
    public ShipStats shipstats;

    public SaveObject()
    {
        coins = 0;
        highscore = 0;

        shipstats = new ShipStats();
        shipstats.maxHealth = 3;
        shipstats.maxLives = 3;
        shipstats.shipSpeed = 3;
        shipstats.fireRate = 0.5f;
    }
}
