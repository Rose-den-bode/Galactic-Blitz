using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public Sprite[] states;

    private int health;
    public AudioClip shieldDamageSFX;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            health--;
            AudioManager.PlaySoundEffect(shieldDamageSFX);

            if (health <= 0)
                Destroy(gameObject);
            else
                sr.sprite = states[health - 1];
        }

        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }


}
