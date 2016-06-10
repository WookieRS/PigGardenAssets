using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private AudioSource audioSource;
	private bool isLevelEnded = false;
	private GameObject winLabel;

	[Tooltip("Время уровня, сек")]
	public float maxLevelTime;
	//public float currentLevelTime;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
		slider.maxValue = maxLevelTime;
		audioSource = GetComponent<AudioSource>();
		winLabel = GameObject.Find ("WinButton");
		winLabel.SetActive (false);

		if (!winLabel) {
			Debug.LogError ("Can't find win button!");
		}

	}
	
	// Update is called once per frame
	void Update () {
		SliderMove ();
		//currentLevelTime = Time.timeSinceLevelLoad;
	}

	void SliderMove(){
		if (slider.value < slider.maxValue) {
			slider.value += Time.deltaTime;
		}
		else if (!isLevelEnded){
			audioSource.Play ();
			winLabel.SetActive (true);
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isLevelEnded = true;

		}
	}

	//TODO:Поменять на nextlevel
	void LoadNextLevel(){
		Debug.Log ("Next level");
		//GameObject.FindObjectOfType<LevelManager>().LoadLevel ("Win");
	}
}
