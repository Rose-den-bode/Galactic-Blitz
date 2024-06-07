using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public TextMeshProUGUI highscoreText;
    private int highscore;

    public TextMeshProUGUI coinsText;

    public TextMeshProUGUI waveText;
    private int wave;

    public Image[] lifeSprites;
    public Image healthBar;

    public SpriteSortPoint[] healthBars;


    private static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
    }

    public static void UpdateLives(int l)
    {

    }
}
