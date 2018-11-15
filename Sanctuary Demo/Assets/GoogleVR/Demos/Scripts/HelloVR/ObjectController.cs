// Copyright 2014 Google Inc. All rights reserved.
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

namespace GoogleVR.HelloVR {
  using UnityEngine;
  using UnityEngine.EventSystems;

  [RequireComponent(typeof(Collider))]
  public class ObjectController : MonoBehaviour {
    private Vector3 startingPosition;
    private Renderer myRenderer;
	public Vector3 selectedSize = new Vector3(0.01f, 0.01f, 0);
	public Vector3 maxSize = new Vector3 (1f, 1f, 0);
	public Vector3 minSize = new Vector3 (0.25f, 0.25f, 0);
	private bool expand = true;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;

    void Start() {
      startingPosition = transform.localPosition;
      myRenderer = GetComponent<Renderer>();
      SetGazedAt(false);
    }

	void Update(){
			Debug.Log(transform.localScale);
			Debug.Log(transform.localScale.x);
			Debug.Log(maxSize.x);
		
		if(transform.localScale.x > maxSize.x){
			expand = false;
				Debug.Log("here");
		}
		else if(transform.localScale.x == minSize.x){
			expand = true;
		}

		if(expand){
			transform.localScale += selectedSize;
		}
		if(!expand) transform.localScale -= selectedSize;	
	}

    public void SetGazedAt(bool gazedAt) {
      if (inactiveMaterial != null && gazedAtMaterial != null) {
        myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        return;
      }
    }

    public void Reset() {
      int sibIdx = transform.GetSiblingIndex();
      int numSibs = transform.parent.childCount;
      for (int i=0; i<numSibs; i++) {
        GameObject sib = transform.parent.GetChild(i).gameObject;
        sib.transform.localPosition = startingPosition;
        sib.SetActive(i == sibIdx);
      }
    }

    public void Recenter() {
#if !UNITY_EDITOR
      GvrCardboardHelpers.Recenter();
#else
      if (GvrEditorEmulator.Instance != null) {
        GvrEditorEmulator.Instance.Recenter();
      }
#endif  // !UNITY_EDITOR
    }

    public void TeleportRandomly(BaseEventData eventData) {
      // Pick a random sibling, move them somewhere random, activate them,
      // deactivate ourself.
      int sibIdx = transform.GetSiblingIndex();
      int numSibs = transform.parent.childCount;
      sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
      GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

      // Move to random new location ±100º horzontal.
      Vector3 direction = Quaternion.Euler(
          0,
          Random.Range(-90, 90),
          0) * Vector3.forward;
      // New location between 1.5m and 3.5m.
      float distance = 2 * Random.value + 1.5f;
      Vector3 newPos = direction * distance;
      // Limit vertical position to be fully in the room.
      newPos.y = Mathf.Clamp(newPos.y, -1.2f, 4f);
      randomSib.transform.localPosition = newPos;

      randomSib.SetActive(true);
      gameObject.SetActive(false);
      SetGazedAt(false);
    }
	public void Breathe(BaseEventData eventData){
			transform.localScale += selectedSize;
		if(transform.localScale.x < maxSize.x){
			transform.localScale += selectedSize;
		}
		else if(transform.localScale.x > minSize.x){
			transform.localScale -= selectedSize;
		}
	}

  }
}
