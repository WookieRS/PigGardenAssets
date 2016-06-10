using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private GameObject defenderParent;
	private StarDisplay starDisplay;
	private Animator starAnimation;

	// Use this for initialization
	void Start () {
		
		defenderParent = GameObject.Find("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}
	

	void OnMouseDown(){
		Vector2 rawPos = CalcWorldOfMouseClick();
		Vector2 roundedPos = RoundPosToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender>().price;

		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (defender, roundedPos);
		} else {
			//Debug.Log ("Не хватает звезд!");
			starAnimation = starDisplay.GetComponent<Animator> ();
			starAnimation.SetTrigger ("notenough");
		}
	}

	//Зачем то выделили в отдельный метод
	void SpawnDefender (GameObject defender, Vector2 roundedPos){
		GameObject newDefender = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;
	}

	Vector2 RoundPosToGrid (Vector2 rawWorldPos){
		float newX = Mathf.Round(rawWorldPos.x);
		float newY = Mathf.Round(rawWorldPos.y);

		return new Vector2(newX, newY);
	}

	Vector2 CalcWorldOfMouseClick(){
		Vector2 worldPos = myCamera.ScreenToWorldPoint (Input.mousePosition);

		return worldPos;
	}
}
