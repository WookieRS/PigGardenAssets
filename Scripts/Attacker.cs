using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Tooltip ("Время между появлениями, сек.")]
	public float seenEverySeconds;
	private GameObject currentTarget;
	private Animator animator;
	private float currentSpeed;

	public float damage;
	public bool haveKnife;
	public GameObject blood;
	public GameObject dust;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
	}

//  Аналогичный метод в классе Melee
//	void OnTriggerEnter2D(){
//		Debug.Log(gameObject + "trigger enter ");
//	}

	public void SetSpeed(float speed){
		currentSpeed = speed;
	}

	//Called from Animator
	public void StrikeCurrentTarget(){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			health.DealDamage (damage);

			if (currentTarget.GetComponent<Defender>().haveBlood && haveKnife) {
				GameObject bloodClone = Instantiate (blood);
				bloodClone.transform.position = transform.position + new Vector3(-0.8f, -0.26f);
				Destroy(bloodClone,1);
			}

			if (currentTarget.GetComponent<Defender>().haveDust) {
				GameObject dustClone = Instantiate (dust);
				//dustClone.transform.position = transform.position + new Vector3(-0.47f, -0.01f);
				dustClone.transform.position = currentTarget.transform.position + new Vector3(0.1f, 0);
				Destroy(dustClone,1);
			}
		}
	}

	public void Attack(GameObject obj){
		currentTarget = obj;
	}

}
