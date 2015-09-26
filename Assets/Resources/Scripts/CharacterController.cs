using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterController : MonoBehaviour 
{
	Rigidbody2D character; 
	float maxSpeed = 5f;
	int collectedPickups;

	Animator anim;

	void Start()
	{
		character = this.GetComponent<Rigidbody2D>(); 
		anim = GetComponent<Animator> ();
		collectedPickups = 0;
	}

	void FixedUpdate () 
	{
		//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		float move = Input.GetAxis ("Horizontal");
		float jump = Input.GetAxis ("Jump");


		anim.SetFloat ("Speed", Mathf.Abs (move));

		character.velocity = new Vector2(move * maxSpeed, character.velocity.y);

		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.99f);

		if (hit.collider != null && hit.collider.tag == "Ground" && !(anim.GetBool("isJumping")) && jump > 0.1) {
			anim.SetBool ("isJumping", true);
			character.AddForce (Vector3.up * 200f);
		} else if (hit.collider != null && anim.GetBool("isJumping")){
			anim.SetBool("isJumping", false);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Water") 
		{
			character.transform.position = new Vector2(-3, 2);
		}
		if (coll.gameObject.tag == "Finish" && collectedPickups == 7) 
		{
			GUIDrawer.endGame();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Pickup") 
		{
			coll.gameObject.SetActive(false);
			AudioSource pickUpSound = GetComponent<AudioSource>();
			pickUpSound.Play();
			
			GUIDrawer.addText(coll.gameObject.name);			
			//Debug.Log(PickupParser.returnText(coll.gameObject.name));
			collectedPickups ++;
		}
	}
}