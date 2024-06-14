using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ShipStats shipStats;

    public AudioClip shootSFX;
    public AudioClip shipDamageSFX;
    public AudioClip exsplotionSFX;

    public GameObject explosion;
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

        UIManager.UpdateHealthbar(shipStats.currentHealth);
        UIManager.UpdateLives(shipStats.currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > MAX_LEFT)
            transform.Translate(Vector2.left * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_RIGHT)
            transform.Translate(Vector2.right * Time.deltaTime * shipStats.shipSpeed);

        if (Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }

    public void IncreaseMaxHealth(int amount)
    {
        shipStats.maxHealth += amount;
    }

    private void TakeDamage()
    {
        AudioManager.PlaySoundEffect(shipDamageSFX);
        shipStats.currentHealth--;
        UIManager.UpdateHealthbar(shipStats.currentHealth);

        if (shipStats.currentHealth <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.PlaySoundEffect(exsplotionSFX);
            shipStats.currentLives--;
            UIManager.UpdateLives(shipStats.currentLives);

            if (shipStats.currentLives <= 0)
            {
                MenuManager.OpenGameOver();
                SaveManager.SaveProgress();
            }
            else
            {
                StartCoroutine(Respawn());
            }
        }
    }

    public void AddHealth()
    {
        if (shipStats.currentHealth == shipStats.maxHealth)
        {
            UIManager.UpdateScore(250);
        }
        else
        {
            shipStats.currentHealth++;
            UIManager.UpdateHealthbar(shipStats.currentHealth);
        }


    }


    public void AddLife()
    {
        if (shipStats.currentLives == shipStats.maxLives)
        {
            UIManager.UpdateScore(1000);
        }
        else
        {
            shipStats.currentLives++;
            UIManager.UpdateLives(shipStats.currentLives);
        }


    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        AudioManager.PlaySoundEffect(shootSFX);
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }

    private IEnumerator Respawn()
    {
        transform.position = offScreenPos;

        yield return new WaitForSeconds(2);

        shipStats.currentHealth = shipStats.maxHealth;
        UIManager.UpdateHealthbar(shipStats.currentHealth);

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
