using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour
{
    public float speed = -10f;
    public Rigidbody2D rb;
    public int damage = 30;
    public static int damageStatic = 30;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        if (NextLevel.hasWin) {
            damage = damageStatic;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null) {
            player.TakeDamage(damage);
        }
        GameObject clone = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(clone, 0.3f);
        Destroy(gameObject);
    }
}
