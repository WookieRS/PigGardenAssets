using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float timerAutoLoadNextLevel;
	static public int losedLevel;

	void Start(){
		if (timerAutoLoadNextLevel != 0) {
			Invoke("LoadNextLevel",timerAutoLoadNextLevel);
		}
	}
		
	public void LoadLevel(string level){
        SceneManager.LoadScene(level);
        
	}

	public void LoadNextLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Quit(){
		Application.Quit();
	}

	public void LoadLastLevel (){
		SceneManager.LoadScene(losedLevel);
	}
}