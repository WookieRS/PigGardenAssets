using UnityEngine;
using System.Collections;

//Класс, отвечающий за здоровье
public class Health : MonoBehaviour {

	public float health;
	public bool haveDeadAnimation;

	private Animator animator;

	void Start () {
		animator = GetComponent<Animator>();
	}

	public void DealDamage(float damage){
		health -= damage;
		if (health <=0 && haveDeadAnimation) {
			animator.SetTrigger ("dead");

		} else if (health <=0) {
			DestroyObject();
		
		}
	}


	public void DestroyObject(){
		Destroy(gameObject);
	}
}
