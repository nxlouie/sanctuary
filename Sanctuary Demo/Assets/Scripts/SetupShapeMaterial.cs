using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupShapeMaterial : MonoBehaviour {
	public GameObject shape;
	public List<Material> mats;
	private Material selectedMat;
	private bool change = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(change) SetupColor();
		change = false;
	}

	public void SetupColor(){
		Debug.Log("Setup shape color");
		string materialName = PlayerPrefs.GetString("Color", "BlueMat");
		foreach(Material mat in mats){
			if(mat.name == materialName){
				selectedMat = mat;
			}
		}
		Renderer shapeRenderer = shape.GetComponent<Renderer>();
		shapeRenderer.material = selectedMat;
	}
}
