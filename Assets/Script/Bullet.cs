using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject impactEffect;
    public static bool isBulletHorizontal = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!isBulletHorizontal) { 
            rb.velocity = transform.up * speed; 
        } else {
            rb.velocity = transform.right * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
        GameObject clone = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(clone, 0.3f);
        Destroy(gameObject);
    }
}
