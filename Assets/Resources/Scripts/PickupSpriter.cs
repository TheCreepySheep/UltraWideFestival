using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupSpriter : MonoBehaviour {

	static SpriteRenderer sprRenderer;
	static Dictionary<string, float> spritedScale;

	void Start()
	{		
		spritedScale = new Dictionary<string, float> ();
		catalogScales ();
		int qualLev = QualitySettings.GetQualityLevel();
		if (qualLev == 1) 
		{
			changeRealistic();
		}
		//Debug.Log (qualLev);
	}

	void changeRealistic()
	{
		foreach (Transform child in transform) 
		{
			//Changing sprite
			sprRenderer = child.GetComponent<SpriteRenderer> ();

			string spriteLoc = string.Concat ("Sprites/Pickups/Level 1/Realistic/", child.name);
			Sprite spr = Resources.Load<Sprite> (spriteLoc);
			sprRenderer.sprite = spr;
			child.localScale = new Vector2(spritedScale[child.name],spritedScale[child.name]);

			if (child.name != "sprite_RAM_snapped")
			{
				//Resizing BoxColliders
				BoxCollider2D boxCol = child.GetComponent<BoxCollider2D>();
				Vector2 newCol = new Vector2(spr.bounds.size.x,spr.bounds.size.y);
				
				boxCol.size = newCol;
				//child.localScale = new Vector2(0.25f, 0.25f);
			}
			else
			{
				changeRealisticRAM(child.gameObject);

				//Debug.Log("Nüüd on else");
			}
		}
	}

	void changeRealisticRAM(GameObject child)
	{
		//Clear previous BoxColliders
		BoxCollider2D[] boxColList = child.GetComponents<BoxCollider2D>();
		foreach(BoxCollider2D boxColVana in boxColList)
		{
			Destroy(boxColVana);
			
		}
		BoxCollider2D boxColLeft = child.AddComponent<BoxCollider2D> ();
		boxColLeft.size = new Vector2 (0.8f, 1.7f);
		boxColLeft.offset = new Vector2 (-0.88f, -0.35f);
		boxColLeft.isTrigger = true;

		BoxCollider2D boxColRight = child.AddComponent<BoxCollider2D> ();
		boxColRight.size = new Vector2 (1.9f, 0.8f);
		boxColRight.offset = new Vector2 (0.33f, 0.81f);
		boxColRight.isTrigger = true;
	}

	static void catalogScales()
	{
		spritedScale.Add ("sprite_GPU", 0.25f); 
		spritedScale.Add ("sprite_CPU", 0.5f);
		spritedScale.Add ("sprite_MoBo", 0.25f); 
		spritedScale.Add ("sprite_PSU", 0.3f);
		spritedScale.Add ("sprite_RAM", 0.4f);
		spritedScale.Add ("sprite_RAM_snapped", 0.4f);
		spritedScale.Add ("sprite_FAN", 0.2f);
	}
}