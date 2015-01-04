using UnityEngine;
using System.Collections;

public class CirculoScript : MonoBehaviour
{

		bool facingRight = true;
		int direction;
		float move;
		Animator anim;

		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				move = -4f;
		}
	
		// Update is called once per frame
		void Update ()
		{

		//Debug.Log (transform.position.x+ " " +transform.position.y);
		if (transform.position.x>10.6f && transform.position.x< 10.8f) {
			move *= -1;
			Flip();
			Debug.Log("Cambio hacia derecha");
			
		} else if (transform.position.x>31.5 && transform.position.x< 31.7f) {
			move *= -1;
			Flip();
			Debug.Log("Cambio hacia derecha");
		}
		}

		void FixedUpdate ()
		{

				anim.SetFloat ("Speed", Mathf.Abs (move));
				rigidbody2D.velocity = new Vector2 (move, rigidbody2D.velocity.y);

		
				/*if (move > 0 && !facingRight) 
			Flip ();
		else if (move < 0 && facingRight) 
			Flip ();*/
		
		
		}


	
		void Flip ()
		{
				facingRight = !facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}
}
