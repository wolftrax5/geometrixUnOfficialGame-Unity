using UnityEngine;
using System.Collections;

public class CubitoScript : MonoBehaviour
{

	
		private float maxSpeed = 7f;
		bool facingRight = true;
		Animator anim;
		bool grounded = false;
		public Transform groundCheck;
		float groundRadius = 0.5f;
		public LayerMask whatIsGround;
		
	
		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
		}
	
		void FixedUpdate ()
		{

				//Vector3 pointCamera = camera.WorldToViewportPoint (transform.position);
				//Debug.Log (pointCamera);		
		
		
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				anim.SetBool ("Ground", grounded);

				anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);



				float move = Input.GetAxis ("Horizontal");

				anim.SetFloat ("Speed", Mathf.Abs (move));
		
				rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		
		
				if (move > 0 && !facingRight)
						Flip ();
				else if (move < 0 && facingRight)
						Flip ();
		
		
		}
	
		// Update is called once per frame
		void Update ()
		{

				if (grounded && Input.GetKeyDown (KeyCode.Space)) {
						anim.SetBool ("Ground", false);
						anim.SetBool ("isJump", true);
						rigidbody2D.AddForce (new Vector2 (0, 350f));
				} else if (!grounded) {
						anim.SetBool ("isJump", false);		
				}
			
		
		}
	
		void Flip ()
		{
				facingRight = !facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}
}
