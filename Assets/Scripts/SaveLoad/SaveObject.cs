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
        shipstats.maxHealth = 1;
        shipstats.maxLives = 3;
        shipstats.shipSpeed = 3;
        shipstats.fireRate = 1f;
    }
}
