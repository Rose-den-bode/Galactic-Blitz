using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ShipStats shipStats;

    public GameObject bulletPrefab;

    private const float MAX_LEFT = -8.3f;
    private const float MAX_RIGHT = 8.3f;

    private Vector2 offScreenPos = new Vector2(0, -20f);
    private Vector2 startPos = new Vector2(0, -4.5f);

    private bool isShooting;


    private void Start()
    {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLives = shipStats.maxLives;

        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && transform.position.x > MAX_LEFT)
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_RIGHT)
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);

        if(Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }


    private void TakeDamage()
    {
        shipStats.currentHealth--;

        if(shipStats.currentHealth <= 0)
        {
            shipStats.currentLives--;

            if(shipStats.currentLives <= 0)
            {
                Debug.Log("GAME OVER");
                // Game Over
            }
            else
            {
                StartCoroutine(Respawn());
            }
        }
    }


    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;

        transform.position = startPos;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
           if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("PLAYER HIT");
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
