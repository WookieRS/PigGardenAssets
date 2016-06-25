using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public float damage;
	public bool explosive = false;
	public GameObject explosivePrefab;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider){
		GameObject target = collider.gameObject;

		if (target.GetComponent<Attacker>()) {
			Health health = target.GetComponent<Health>();
			health.DealDamage (damage);

			if (explosive) {
				Explode ();
			}

			Destroy (gameObject);
		}
	}

	void Explode ()	{
		GameObject explodeClone = Instantiate (explosivePrefab);
		explodeClone.transform.position = transform.position;
		Destroy (explodeClone, 1.5f);
	}

	void OnBecameInvisible(){
		Destroy (gameObject);
	}
}
