using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;

public class WeatherController : MonoBehaviour {
	private const string API_KEY = "6c18396bfd5880ac699ce35f2f35ea21";
	private const float API_CHECK_MAXTIME = 10 * 60.0f; //10 minutes
	public GameObject SnowSystem;
	public string CityName;
	private float apiCheckCountdown = API_CHECK_MAXTIME;

	void Start()
	{
		UpdateWeatherStatus();
	}
	void Update()
	{
		apiCheckCountdown -= Time.deltaTime;
		if (apiCheckCountdown <= 0)
		{
			UpdateWeatherStatus();
			apiCheckCountdown = API_CHECK_MAXTIME;
		}
	}
	public void UpdateWeatherStatus()
	{	
		/* SNOW EXAMPLE */
		WeatherInfo weatherInfo = GetWeather();

		// UNCOMMENT NEXT LINE IF YOU WANT TO SEE SNOW FOR SURE
		// weatherInfo.weather[0].main = "Snow";
		bool snowing = weatherInfo.weather[0].main.Equals("Snow");
		if (snowing) {
			SnowSystem.SetActive (true);
			// code to change skybox and terrain
		} else {
			SnowSystem.SetActive (false);
		}

		// TO GENERALIZE:
		// loop over active conditions in weatherInfo.weather


	}
	private WeatherInfo GetWeather()
	{
		HttpWebRequest request = 
			(HttpWebRequest)WebRequest.Create(String.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}", 
				CityName, API_KEY));
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		StreamReader reader = new StreamReader(response.GetResponseStream());
		string jsonResponse = reader.ReadToEnd();
		WeatherInfo info = JsonUtility.FromJson<WeatherInfo>(jsonResponse);
		return info;
	}
}
