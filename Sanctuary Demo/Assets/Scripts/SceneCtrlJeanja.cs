using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrlJeanja : MonoBehaviour {
	public List<GameObject> colorButtons;
	public List<GameObject> shapes;

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void ChangeSceneIdx(int sceneID)
	{
		SceneManager.LoadScene (sceneID);
	}

	public void QuitApp()
	{
		Application.Quit();
	}

	public void ShowColorButtons(GameObject menuButton)
	{
		menuButton.SetActive(false);
		foreach(GameObject button in colorButtons){
			button.SetActive(true);
		}
	}

	public void CloseColorMenu(GameObject menuButton){
		foreach(GameObject button in colorButtons){
			button.SetActive(false);
		}
		menuButton.SetActive(true);
	}

	public void ChangeColor(Material selectedMat){
		PlayerPrefs.SetString("Color", selectedMat.name); 
		foreach(GameObject shape in shapes){
			Renderer shapeRenderer = shape.GetComponent<Renderer>();
			shapeRenderer.material = selectedMat;
		}
	}

	public void ToggleTutorial(){
		if (PlayerPrefs.GetString ("Tutorial") == "on") {
			PlayerPrefs.SetString ("Tutorial", "off");
			print ("on to off");
			print (PlayerPrefs.GetString ("Tutorial"));
		} else {
			PlayerPrefs.SetString ("Tutorial", "on");
			print ("off to on");
			print (PlayerPrefs.GetString ("Tutorial"));
		}
	}
}