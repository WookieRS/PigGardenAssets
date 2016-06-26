using UnityEngine;
using System.Collections;

public class Confetti : MonoBehaviour {

	public GameObject confetti;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreateConfetti", 2.2f, 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void CreateConfetti(){
		GameObject confettiClone = Instantiate (confetti);
		Destroy (confettiClone, 7);
	}
}
