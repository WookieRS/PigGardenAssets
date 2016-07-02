using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;

	public int starsAmount = 500;
	private int amountPerFlower;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		//starText = Text.FindObjectOfType<Text>(); - т.к. компонент в данном объекте, то его не нужно искать
		starText = GetComponent<Text>();
		UpdateStarText ();
		int difficulty = PlayerPrefsManager.GetDifficulty ();
		switch (difficulty) {
		case 3:
			amountPerFlower = 10;
			break;
		case 2:
			amountPerFlower = 12;
			break;
		case 1:
			amountPerFlower = 16;
			break;
		default:
			amountPerFlower = 12;
			break;
		}


	}

	public void AddStars(){
		starsAmount += amountPerFlower;
		UpdateStarText ();
	}

	public Status UseStars(int amount){
		if (starsAmount >= amount) {
			starsAmount -= amount;
			UpdateStarText ();
			return Status.SUCCESS;
		} else {
			return Status.FAILURE;
		}
	}

	void UpdateStarText(){
		starText.text = starsAmount.ToString ();
	}
}
