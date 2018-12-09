using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JeanjaRotate : MonoBehaviour {
    Stopwatch sw = Stopwatch.StartNew();

	float rate = 0.05f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sw.Elapsed.TotalMilliseconds < 5970) {
			transform.Rotate(0, 26f, 0);
		}
		else if (sw.Elapsed.TotalMilliseconds > 5970 && sw.Elapsed.TotalMilliseconds < 50000) {
			transform.Rotate(0, 0.05f, 0);
		}
		else if (sw.Elapsed.TotalMilliseconds > 50000 && sw.Elapsed.TotalMilliseconds < 70000) {
			transform.Rotate(0, 0.075f, 0);
		}
		else if (sw.Elapsed.TotalMilliseconds > 70000 && sw.Elapsed.TotalMilliseconds < 89000) {
			transform.Rotate(0, 0.2f, 0);
		}
		else if (sw.Elapsed.TotalMilliseconds > 89000) {
			transform.Rotate(0, 20f, 0);
		}
		// (x, y, z)
	}
}
