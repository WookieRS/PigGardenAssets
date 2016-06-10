using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (){
		GameObject.FindObjectOfType<LevelManager>().LoadLevel ("Lose");
		LevelManager.losedLevel = SceneManager.GetActiveScene().buildIndex;

	}
}
