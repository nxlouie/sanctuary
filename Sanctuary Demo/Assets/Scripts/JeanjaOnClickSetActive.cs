using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanjaOnClickSetActive : MonoBehaviour {
	public GameObject campfire;
	public void OnClick() {
		campfire.transform.GetChild(0).gameObject.SetActive(false);
	}

}
