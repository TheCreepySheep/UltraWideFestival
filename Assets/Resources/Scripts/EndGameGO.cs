using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameGO : MonoBehaviour 
{
	static Text currText;

	void Start()
	{
		currText = gameObject.GetComponent<Text> ();
	}

	public static void endGame()
	{
		currText.text = "Game over!";
	}
}