using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public float shotRate = 2f;
    float nextShotTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextShotTime) {
            if (Input.GetButtonDown("Fire1")) {
                Shoot();
                nextShotTime = Time.time + 1f / shotRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
