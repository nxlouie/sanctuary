using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupTutorial : MonoBehaviour {
	public GameObject menu;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("Tutorial") == "off") {
			menu.SetActive (false);
		} else {
			menu.SetActive (true);
		}
	}
}

