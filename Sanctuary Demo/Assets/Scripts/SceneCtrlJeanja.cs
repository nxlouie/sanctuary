﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrlJeanja : MonoBehaviour {
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
}