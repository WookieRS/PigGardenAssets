using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public bool haveBlood;
	public bool haveDust;
	public int price = 100;

	private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddStars(int count){
		starDisplay.AddStars (count);

	}

//  Пока не используется
//	void OnTriggerEnter2D(){
//		Debug.Log(gameObject + "triggered enter ");
//	}

}
