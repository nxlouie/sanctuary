using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spin : MonoBehaviour {

	public float spinValue = 90;
	private bool spinning = false;
	private Vector3 startingPosition;
	private Renderer myRenderer;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;

	// Use this for initialization
	void Start() {
		startingPosition = transform.localPosition;
		myRenderer = GetComponent<Renderer>();
		SetGazedAt(false);
	}

	public void SetGazedAt(bool gazedAt) {
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (spinning) {
			transform.Rotate (Vector3.up * spinValue * Time.deltaTime);
		}
	}

	public void StopSpinning(BaseEventData eventData) {
		spinning = true;
	}
}
