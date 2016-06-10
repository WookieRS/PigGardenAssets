using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject buttonPrefabOnStart;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Text costText;
	private int cost;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		costText = GetComponentInChildren<Text>();
		cost = buttonPrefab.GetComponent<Defender>().price;
		costText.text = cost.ToString ();

		selectedDefender = buttonPrefabOnStart;
	}

	void OnMouseDown(){

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.gray;
		}

		//GetComponent<SpriteRenderer>().color = Color.white;
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		Color color = renderer.color;
		color = Color.white;
		color.a = 1f;
		renderer.color = color;


		selectedDefender = buttonPrefab;
	}
}
