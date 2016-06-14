using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public GameObject explosive;
	public GameObject explosiveSound;

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

		GameObject explosiveSoundClone = Instantiate (explosiveSound);
		Destroy (explosiveSoundClone, 2.5f);
	}
}
