using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{

    private Collider2D playerCollider;
	private Rigidbody2D rb;
	private bool facingRight = true;

	[SerializeField] private float m_JumpForce = 400f;

	private Vector3 m_Velocity = Vector3.zero;

	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		//playerCollider = GetComponent<Collider2D>;
    }

    // Update is called once per frame
    void Update()
    {
		
	}

	public void Move(float move, bool jumping){
		Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);

		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		if (move > 0 && !facingRight)
		{
			// ... flip the player.
			Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0 && facingRight)
		{
			// ... flip the player.
			Flip();
		}

		if(jumping){
			rb.AddForce(new Vector2(0f, m_JumpForce));
		}

	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		transform.Rotate(0f, 180f, 0f);
	}
}
