using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float moveSpeed = 5f;
    Vector2 movement;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(movement.x) > 0)
            animator.SetFloat("Speed", Mathf.Abs(movement.x));
        if (Mathf.Abs(movement.y) > 0)
            animator.SetFloat("Speed", Mathf.Abs(movement.y));
        else if (Mathf.Abs(movement.x) == 0 && (Mathf.Abs(movement.y) == 0))
            animator.SetFloat("Speed", 0);

        if (Input.GetButtonDown("Space")) {
            animator.SetBool("IsShootingUp", true);
            Bullet.isBulletHorizontal = false;
        }
        if (Input.GetButtonUp("Space")){
            animator.SetBool("IsShootingUp", false);
            Bullet.isBulletHorizontal = true;
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // If the input is moving the player right and the player is facing left...
        if (movement.x > 0 && !m_FacingRight)
        {
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (movement.x < 0 && m_FacingRight)
        {
            Flip();
        }
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}
}
