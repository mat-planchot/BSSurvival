using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float shotRate = 0.5f;
    float nextShotTime = 0f;

    public void AttackDart()
    {
        if (Time.time >= nextShotTime) {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            nextShotTime = Time.time + 1f / shotRate;
        }
    }

    void Update()
    {
        if (Time.time >= nextShotTime) {
            Shoot();
            nextShotTime = Time.time + 1f / shotRate;
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
