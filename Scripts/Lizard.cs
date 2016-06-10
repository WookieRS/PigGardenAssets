using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;

		//leave method if collider is NOT defender
		if (!obj.GetComponent<Defender>()) {
			return;
		} 

		if (obj.GetComponent<Defender>()) {
			anim.SetBool("isAttacking",true);
			attacker.Attack (obj);
		} 



		Debug.Log(name + " collided with " + collider);
		//Attacker.StrikeCurrentTarget(1.2f);
	}
}
