using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    private bool Cooldown;
    private float cooldownTimer;
    public float TTA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !Cooldown)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Cooldown = true;

        }
        
        if (Cooldown)
            {
                cooldownTimer += Time.deltaTime;

                if (cooldownTimer >= TTA)
                {
                    cooldownTimer = 0;
                    Cooldown = false;
                }
            }
    }
}
