using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameCM : MonoBehaviour 
{
	static Text currText;
	
	void Start()
	{
		currText = gameObject.GetComponent<Text> ();
	}
	
	public static void endGame()
	{
		currText.text = "You have collected every piece in my computer";
	}
}