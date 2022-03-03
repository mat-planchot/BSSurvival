using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 300;

    public GameObject deathEffect;

    public void TakeDamage(int damage) 
    {
        health -= damage;
        StartCoroutine(DamageAnimation());
        if (health <= 0) {
            Die();
        }
    }

    void Die()
    {
        GameObject clone = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(clone, 0.6f);
        Destroy(gameObject);
    }

    IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}
