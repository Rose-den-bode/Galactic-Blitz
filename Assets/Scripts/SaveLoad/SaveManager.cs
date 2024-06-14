using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public GameObject ship;

    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        SaveObject so = SaveLoad.LoadState();
    }

    public static void SaveProgress()
    {
        SaveObject so = new SaveObject();

        so.coins = Invetory.currentCoins;
        so.highscore = UIManager.GetHighscore();
        so.shipstats = GameObject.FindWithTag("Player").GetComponent<Player>().shipStats;

        SaveLoad.SaveState(so);
    }

    public static void LoadProgress()
    {
        SaveObject so = SaveLoad.LoadState();

        Invetory.currentCoins = so.coins;
        UIManager.UpdateHighscore(so.highscore);

        GameObject.FindWithTag("Player").GetComponent<Player>().shipStats = so.shipstats;
    }
}
