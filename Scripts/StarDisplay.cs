using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;

	public int starsAmount = 500;
	public enum Status {SUCCESS, FAILURE};

	// Use this for initialization
	void Start () {
		//starText = Text.FindObjectOfType<Text>(); - т.к. компонент в данном объекте, то его не нужно искать
		starText = GetComponent<Text>();
		UpdateStarText ();
	}

	public void AddStars(int amount){
		starsAmount += amount;
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
