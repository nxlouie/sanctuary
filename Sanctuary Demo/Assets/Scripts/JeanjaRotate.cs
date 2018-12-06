using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanjaRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// (x, y, z)
		transform.Rotate(0, 0.05f, 0);
	}
}
