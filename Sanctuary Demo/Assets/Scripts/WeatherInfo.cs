using System;
using System.Collections.Generic;

[Serializable]
public class Weather
{
	public int id;
	public string main;
}
[Serializable]
public class WeatherInfo
{
	public int id;
	public string name;
	public List<Weather> weather;
}
