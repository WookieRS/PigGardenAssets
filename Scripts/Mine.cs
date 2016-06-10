using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject explosive;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.GetComponent<Attacker>()) {
			Invoke ("ExplodeBomb", 0.5f);
			Destroy (gameObject, 0.5f);
		}
	}

	void ExplodeBomb ()	{
		GameObject explodeClone = Instantiate (explosive);
		explodeClone.transform.position = transform.position;
		Destroy (explodeClone, 0.9f);
	}
}
