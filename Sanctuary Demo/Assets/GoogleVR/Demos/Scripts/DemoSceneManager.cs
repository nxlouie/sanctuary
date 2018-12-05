// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace GoogleVR.Demos {
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;

  // Ensures correct app and scene setup.
  public class DemoSceneManager : MonoBehaviour {
	public List<GameObject> shapes;
	public List<Material> mats;
	private Material selectedMat;
	
    void Start() {
      Input.backButtonLeavesApp = true;
	  string materialName = PlayerPrefs.GetString("Color", "BlueMat");
	  foreach(Material mat in mats){
	  	if(mat.name == materialName){
			selectedMat = mat;
		}
	  }
	  foreach(GameObject shape in shapes){
	  	Renderer shapeRenderer = shape.GetComponent<Renderer>();
		shapeRenderer.material = selectedMat;
	  }
    }

    void Update() {
      // Exit when (X) is tapped.
      if (Input.GetKeyDown(KeyCode.Escape)) {
        Application.Quit();
      }
    }
  }
}
