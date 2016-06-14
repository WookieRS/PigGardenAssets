using UnityEngine;
using System.Collections;

public class Explosive : MonoBehaviour {

	private CircleCollider2D circleCollider;

	void Start(){
		circleCollider = GetComponent<CircleCollider2D> ();

	}
	//пока на работает
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Attacker>()) {
			collider.GetComponent<Health>().DealDamage (100);
			DisableCollider ();
		}
	}
	
	void DisableCollider(){
		Destroy (circleCollider, 0.6f);
	}
}
