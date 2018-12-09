using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliderControl : MonoBehaviour {

	public AudioMixer mixer;

	public void SetLevel (float sliderValue)
	{
		mixer.SetFloat("VolumeMaster", Mathf.Log10(sliderValue) * 20);
	}
}