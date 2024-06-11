using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] allAlienSets;

    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(0,5.5f);

    private static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }

    public static void CancelGame()
    {
        instance.StopAllCoroutines();

        AlienMaster.allAliens.Clear();

        if (instance.currentSet != null)
            Destroy(instance.currentSet);

        UIManager.ResetUI();
    }

    private IEnumerator SpawnWave()
    {
        AlienMaster.allAliens.Clear();

        if (currentSet != null)
            Destroy(currentSet);

        yield return new WaitForSeconds(3);

        currentSet = Instantiate(allAlienSets[Random.Range(0, allAlienSets.Length)], spawnPos, Quaternion.identity);
        UIManager.UpdateWave();
    }



}
