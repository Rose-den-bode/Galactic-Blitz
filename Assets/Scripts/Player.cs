using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;

    private const float MAX_LEFT = -8.3f;
    private const float MAX_RIGHT = 8.3f;

    private float speed = 3;
    private float cooldown = 0.5f;

    private bool isShooting;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && transform.position.x > MAX_LEFT)
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.D) && transform.position.x < MAX_RIGHT)
            transform.Translate(Vector2.right * Time.deltaTime * speed);

        if(Input.GetKey(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot());
    }
    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }
}
