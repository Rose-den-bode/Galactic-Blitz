using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
public GameObject mainMenu;
public GameObject gameOverMenu;
public GameObject shopMenu;
public GameObject inGameMenu;
public GameObject pauseMenu;

    public static MenuManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        ReturnToMainMenu();
    }


    public  void OpenMainMenu()
    {
        Instance.mainMenu.SetActive(true);
        Instance.inGameMenu.SetActive(false);
    }

    public static void OpenGameOver()
    {
        Time.timeScale = 0;
        UIManager.HighscoreCheck();

        Instance.gameOverMenu.SetActive(true);
        Instance.inGameMenu.SetActive(false);
    }

    public static void GameOverToMainMenu()
    {
        Time.timeScale = 1;

        Instance.inGameMenu.SetActive(false);
        Instance.pauseMenu.SetActive(false);
        Instance.shopMenu.SetActive(false);
        Instance.gameOverMenu.SetActive(false);

        Instance.mainMenu.SetActive(true);
        UIManager.HighscoreCheck();
        GameManager.CancelGame();
    }

    public  void OpenShop()
    {
        Instance.mainMenu.SetActive(false);
        Instance.shopMenu.SetActive(true);
        
    }

    public  void CloseShop()
    {
        Instance.mainMenu.SetActive(true);
        Instance.shopMenu.SetActive(false);

    }

    public static void OpenInGame()
    {
        Time.timeScale = 1;

        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.shipStats.currentHealth = player.shipStats.maxHealth;
        player.shipStats.currentLives = player.shipStats.maxLives;

        UIManager.UpdateHealthbar(player.shipStats.currentHealth);

        Instance.mainMenu.SetActive(false);
        Instance.pauseMenu.SetActive(false);
        Instance.shopMenu.SetActive(false);
        Instance.gameOverMenu.SetActive(false);
        Instance.inGameMenu.SetActive(true);

        GameManager.SpawnNewWave();
    }

    public static void OpenPause()
    {
        Time.timeScale = 0;
        Instance.inGameMenu.SetActive(false);
        Instance.pauseMenu.SetActive(true);
    }

    public static void ClosePause()
    {
        Time.timeScale = 1;
        Instance.inGameMenu.SetActive(true);
        Instance.pauseMenu.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;

        Instance.inGameMenu.SetActive(false);
        Instance.pauseMenu.SetActive(false);
        Instance.shopMenu.SetActive(false);
        Instance.gameOverMenu.SetActive(false);

        Instance.mainMenu.SetActive(true);
        GameManager.CancelGame();
    }

    public static void CloseWindow(GameObject go)
    {
        go.SetActive(false);
    }


}
