﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultSlider;
	public LevelManager levelManager;

	private MusicManager musicManager;


	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultSlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume(volumeSlider.value);
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume (volumeSlider.value);
		PlayerPrefsManager.SetDifficulty (difficultSlider.value);
		levelManager.LoadLevel("Start");
	}

	public void SetDefaults(){
		volumeSlider.value = 0.3f;
		difficultSlider.value = 2f;
		//Screen.SetResolution(1920,1050,true);
	
	}
}
