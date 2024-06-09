// Ignore Spelling: mothership

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject mothershipPrefab;

    private Vector3 hMoveDistance = new Vector3 (0.15f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.25f, 0);
    private Vector3 motherShipSpawnPos = new Vector3 (10f, 3.45f, 0);

    private const float MAX_LEFT = -8.3f;
    private const float MAX_RIGHT = 8.3f;
    private const float MAX_MOVE_SPEED = 0.02f;

    private float moveTimer = 0.01f;
    private const float moveTime = 0.005f;

    private float shootTimer = 3f;
    private const float shootTime = 3f;

    private float mothershipTimer = 1f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;

    private bool movingRight;

    public static List<GameObject> allAliens = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien")) 
            allAliens.Add(go);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTimer <= 0)
            MoveEnemies();

        if (shootTimer <= 0)
            Shoot();

        if (mothershipTimer <=0)
            SpawnMothership();

        moveTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        mothershipTimer -= Time.deltaTime;
    }

    private void MoveEnemies()
    {
        if(allAliens.Count > 0)
        {
            int hitMax =0;

            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                    allAliens[i].transform.position += hMoveDistance;
                else
                    allAliens[i].transform.position -= hMoveDistance;

                if (allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT)
                    hitMax++;
            }

            if(hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                    allAliens[i].transform.position -= vMoveDistance;

                movingRight = !movingRight;
            }

            moveTimer = GetMoveSpeed();

        }
    }

    private void Shoot()
    {
        Vector2 pos = allAliens[Random.Range(0, allAliens.Count)].transform.position;

        Instantiate(bulletPrefab, pos, Quaternion.identity);

        shootTimer = shootTime;
    }

    private void SpawnMothership()
    {
        Instantiate(mothershipPrefab, motherShipSpawnPos, Quaternion.identity);
        mothershipTimer = Random.Range(MOTHERSHIP_MIN, MOTHERSHIP_MAX);
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;

        if (f < MAX_MOVE_SPEED)
            return MAX_MOVE_SPEED;
        else
            return f;  
    }

}
