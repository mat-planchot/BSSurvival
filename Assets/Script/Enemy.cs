using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int attackDamage = 40;
    public GameObject deathEffect;
    public Vector3 attackOffset;
    public float attackRange;
    public LayerMask attackMask;

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) {
            Die();
        }
    }

    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
		}
	}

    void Die()
    {
        GameObject clone = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(clone, 0.6f);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
