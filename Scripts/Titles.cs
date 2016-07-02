using UnityEngine;
using System.Collections;

public class Titles : MonoBehaviour {

	public LevelManager levelManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Exit();
		}
	}

	public void Exit(){
		levelManager.LoadLevel ("Start");
	}
}
