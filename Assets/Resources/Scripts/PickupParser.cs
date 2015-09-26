using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickupParser : MonoBehaviour {

	static Dictionary<string, string> pickups;

	void Start () 
	{
		pickups = new Dictionary<string, string> ();

		pickups.Add("sprite_MoBo", "MSI B75-G41");
		pickups.Add("sprite_CPU", "Intel i5-3450");
		pickups.Add("sprite_GPU", "Gigabyte GTX 660 OC");
		pickups.Add("sprite_PSU", "Codegen 600w");
		pickups.Add("sprite_RAM", "Kingston 8GB");
		pickups.Add("sprite_RAM_snapped", "Kingston 8GB (leaking)");
		pickups.Add("sprite_FAN", "Arctic Freezer 11 LP");
	}
	
	public static string returnText(string name)
	{
		return pickups[name];
	}
}