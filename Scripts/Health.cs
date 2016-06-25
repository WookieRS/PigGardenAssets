using UnityEngine;
using System.Collections;

//Класс, отвечающий за здоровье
public class Health : MonoBehaviour {

	public float health;
	public bool haveDeadAnimation;
	public GameObject deadSound;

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}

	public void DealDamage(float damage){
		health -= damage;
		if (health <=0 && haveDeadAnimation) {
			PlayDeadSound ();
			animator.SetTrigger ("dead");

		} else if (health <=0) {
			PlayDeadSound ();
			DestroyObject();
		}
	}


	public void DestroyObject(){
		Destroy(gameObject);
	}

	public void PlayDeadSound(){
		GameObject deadSoundClone = Instantiate (deadSound);
		Destroy (deadSoundClone,2);
	}
}
