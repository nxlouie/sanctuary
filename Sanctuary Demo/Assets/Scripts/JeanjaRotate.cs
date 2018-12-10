using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class JeanjaRotate : MonoBehaviour {
    Stopwatch sw = Stopwatch.StartNew();

	float rate = 0.2f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sw.Elapsed.TotalMilliseconds < 5700) {
			if (rate < 0.5f) {
				rate = rate + 0.05f;
			}
			transform.Rotate(0, rate, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 5700 && sw.Elapsed.TotalMilliseconds < 48100) {
			transform.Rotate(0, 0.05f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 48100 && sw.Elapsed.TotalMilliseconds < 69700) {
			transform.Rotate(0, 0.075f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 69700 && sw.Elapsed.TotalMilliseconds < 88700) {
			transform.Rotate(0, 0.2f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 88700 && sw.Elapsed.TotalMilliseconds < 122100) {
			transform.Rotate(0, rate, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 122100) {
			if (rate > 0.075f) {
				rate = rate - 0.1f;
			}
			transform.Rotate(0, rate, 0); // (x, y, z)
		}
	}
}
