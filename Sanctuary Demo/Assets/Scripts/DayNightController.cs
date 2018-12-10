using UnityEngine;
using System.Collections;
using System;


public class DayNightController : MonoBehaviour
{
	public Material dawnDuskSkybox;
	public Material daySkybox;
	public Material nightSkybox;

	private TimeSpan dawnTime; 
	private TimeSpan dayTime;
	private TimeSpan duskTime;
	private TimeSpan nightTime;

	/// <summary>
	/// Initializes working variables.
	/// </summary>
	void Initialize()
	{
		dawnTime = new TimeSpan (8, 0, 0);
		dayTime = new TimeSpan (10, 0, 0);
		duskTime = new TimeSpan (17, 0, 0);
		nightTime = new TimeSpan (19, 0, 0);
	}

	// Use this for initialization
	void Start()
	{
		Initialize();
	}

	// Update is called once per frame
	void Update()
	{

		TimeSpan time = DateTime.Now.TimeOfDay;

		// USE THIS LINE TO TEST AT SPECIFIED TIME
		// TimeSpan time = new TimeSpan (20, 0, 0);

		if (time < dawnTime) {
			print ("NIGHTIME");
			RenderSettings.skybox = nightSkybox;
		} else if (time < dayTime) {
			print ("DAWNTIME");
			RenderSettings.skybox = dawnDuskSkybox;
		} else if (time < duskTime) {
			print ("DAYTIME");
			RenderSettings.skybox = daySkybox;
		} else if (time < nightTime) {
			print ("DUSKTIME");
			RenderSettings.skybox = dawnDuskSkybox;
		} else {
			print ("NIGHTTIME");
			RenderSettings.skybox = nightSkybox;
		}
	}
}