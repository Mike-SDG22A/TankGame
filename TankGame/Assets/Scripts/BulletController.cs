using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletTtl = 5;
    [SerializeField]
    GameObject particleSystem;
    [SerializeField]
    Transform bullet;
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(particleSystem, bullet.position, bullet.rotation);
        Destroy(gameObject);
    }
}
