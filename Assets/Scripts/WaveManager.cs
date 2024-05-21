
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyWaveCheck;
    public List<GameObject> waveForms;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void WaveChecker()
    {
        if (enemyWaveCheck.transform.childCount == 0)
        {
            Debug.Log("Youri is lief");
        }
    }
}
