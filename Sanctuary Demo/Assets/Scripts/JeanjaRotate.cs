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
		if (sw.Elapsed.TotalMilliseconds < 5950) {
			if (rate < 0.5f) {
				rate = rate + 0.05f;
			}
			transform.Rotate(0, rate, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 5950 && sw.Elapsed.TotalMilliseconds < 48350) {
			transform.Rotate(0, 0.05f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 48350 && sw.Elapsed.TotalMilliseconds < 69950) {
			transform.Rotate(0, 0.075f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 69950 && sw.Elapsed.TotalMilliseconds < 88950) {
			transform.Rotate(0, 0.2f, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 88950 && sw.Elapsed.TotalMilliseconds < 122350) {
			transform.Rotate(0, rate, 0); // (x, y, z)
		}
		else if (sw.Elapsed.TotalMilliseconds > 122350) {
			if (rate > 0.175f) {
				rate = rate - 0.1f;
			}
			transform.Rotate(0, rate, 0); // (x, y, z)
		}
	}
}
