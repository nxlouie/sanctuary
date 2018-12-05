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
		CheckSnowStatus();
	}
	void Update()
	{
		apiCheckCountdown -= Time.deltaTime;
		if (apiCheckCountdown <= 0)
		{
			CheckSnowStatus();
			apiCheckCountdown = API_CHECK_MAXTIME;
		}
	}
	public void CheckSnowStatus()
	{
		bool snowing = GetWeather().weather[0].main.Equals("Clouds");
		if (snowing)
			SnowSystem.SetActive(true);
		else
			SnowSystem.SetActive(false);
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
