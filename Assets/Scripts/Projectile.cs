using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed;
    public GameObject explosionPrefab;
    private PointManager pointManager;

    // Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy 1") 
        { 
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(10);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Enemy 2")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(20);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Enemy 3")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(40);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
