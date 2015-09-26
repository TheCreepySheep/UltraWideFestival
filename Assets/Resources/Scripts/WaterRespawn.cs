using UnityEngine;
using System.Collections;

public class WaterRespawn : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Pickup") 
		{
			coll.gameObject.SetActive(false);
		}
		
		if (coll.gameObject.name == "Character") 
		{
			coll.transform.position = new Vector2(-2, 2);
		}
	}
}
