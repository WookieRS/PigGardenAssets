using UnityEngine;
using System.Collections;

public class Explosive : MonoBehaviour {


	//пока на работает
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Attacker>()) {
			collider.GetComponent<Health>().DealDamage (100);
		}
	}
	

}
