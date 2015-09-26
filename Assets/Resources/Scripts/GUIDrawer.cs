using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GUIDrawer : MonoBehaviour {

	static int lastFieldAdd;
	static int lastFieldRead;

	static Dictionary<int, GameObject> partFields;

	void Start()
	{
		partFields = new Dictionary<int, GameObject>();

		lastFieldAdd = 1;
		lastFieldRead = 1;

		foreach (Transform child in transform) 
		{
			if (child.name != "GameOver" || child.name != "Collectedmessage")
			{
				partFields.Add(lastFieldAdd, child.gameObject);
			}

			Text currentField = child.gameObject.GetComponent<Text> ();

			currentField.text = string.Empty;
			lastFieldAdd ++;			
		}
	}

	public static void addText (string name) 
	{
		string getInfo = PickupParser.returnText(name);

		Text currentGOtext = partFields [lastFieldRead].gameObject.GetComponent<Text> ();
		currentGOtext.text = getInfo;
		lastFieldRead ++;
	}
	public static void endGame()
	{
		EndGameGO.endGame ();
		EndGameCM.endGame ();
	}
}