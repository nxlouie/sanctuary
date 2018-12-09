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
		if (sw.Elapsed.TotalMilliseconds < 7600) {
			transform.Rotate(0, 20f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 7600 && sw.Elapsed.TotalMilliseconds < 50000) {
			transform.Rotate(0, 0.05f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 50000 && sw.Elapsed.TotalMilliseconds < 71600) {
			transform.Rotate(0, 0.075f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 71600 && sw.Elapsed.TotalMilliseconds < 90600) {
			transform.Rotate(0, 0.2f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 90600 && sw.Elapsed.TotalMilliseconds < 129000) {
			transform.Rotate(0, 18f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 129000) {
			transform.Rotate(0, 0.05f, 0); // (x, y, z)
		}
	}
}
