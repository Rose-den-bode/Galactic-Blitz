// Ignore Spelling: Mothership

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{

    public int scoreValue;

    public GameObject explosion;
    public AudioClip exsplotionSFX;


    private const float MAX_LEFT = -10f;
    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x <= MAX_LEFT)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            UIManager.UpdateScore(scoreValue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            AudioManager.PlaySoundEffect(exsplotionSFX);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
