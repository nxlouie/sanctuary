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
	private Vector3 selectedSize = new Vector3(0.004f, 0.004f, 0);
	private Vector3 maxSize = new Vector3 (1.1f, 1.1f, 0);
	private Vector3 minSize = new Vector3 (0.3f, 0.3f, 0);
	private bool expand = true;
	private bool hold = false;
	private int holdCount = 0;

    public Material inactiveMaterial;
    public Material gazedAtMaterial;
	public UnityEngine.UI.Text breatheText;

    void Start() {
      startingPosition = transform.localPosition;
      myRenderer = GetComponent<Renderer>();
      SetGazedAt(false);
    }

	void Update(){
		if(!hold){
			if(transform.localScale.x > maxSize.x){
				breatheText.text = "Hold";
				expand = false;
				hold = true;
			}
			else if(transform.localScale.x < minSize.x){
				expand = true;
				hold = true;
			}
			if(expand) transform.localScale += selectedSize;
			if(!expand) transform.localScale -= selectedSize;
		}
		else{
			holdCount += 1;
			if(!expand && holdCount == 85){
				breatheText.text = "Breathe Out";
				hold = false;
				holdCount = 0;
			}
			if(expand && holdCount == 25){
				breatheText.text = "Breathe In";
				hold = false;
				holdCount = 0;
			}
		}
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
	public void ChangeShape(BaseEventData eventData){
		int sibIdx = transform.GetSiblingIndex();
		int numSibs = transform.parent.childCount;
		sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
		GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;
		randomSib.SetActive(true);
		gameObject.SetActive(false);
	}

  }
}
