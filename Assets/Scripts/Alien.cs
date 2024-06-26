using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;

    public GameObject coinPrefab;
    public GameObject lifePrefab;
    public GameObject healthPrefab;

    public GameObject explosion;
    public AudioClip exsplotionSFX;

    private const int LIFE_CHANCE = 1;
    private const int HEALTH_CHANCE = 10;
    private const int COIN_CHANCE = 50;

    public void kill()
    {
        UIManager.UpdateScore(scoreValue);

        AlienMaster.allAliens.Remove(gameObject);

        int ran = Random.Range(0, 1000);

        if (ran == LIFE_CHANCE)
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        else if (ran <= HEALTH_CHANCE)
            Instantiate(healthPrefab, transform.position, Quaternion.identity);
        else if(ran <= COIN_CHANCE)
            Instantiate(coinPrefab, transform.position, Quaternion.identity);

        Instantiate(explosion, transform.position, Quaternion.identity);
        AudioManager.PlaySoundEffect(exsplotionSFX);

        if (AlienMaster.allAliens.Count == 0)
            GameManager.SpawnNewWave();

        Destroy(gameObject);
    }

}
