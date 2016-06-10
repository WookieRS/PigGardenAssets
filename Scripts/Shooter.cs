﻿using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {


	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	
	// Use this for initialization
	void Start () {
		SetMyLaneSpawner();

		animator = GameObject.FindObjectOfType<Animator>();
		projectileParent = GameObject.Find("Projectiles");
		
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}

	void Update(){
		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	bool IsAttackerAheadInLane(){
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		//Attackers ahead?
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//Atteckers behind;
		return false;
	}


	void SetMyLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

		foreach (Spawner spawner in spawnerArray) {
			if (transform.position.y == spawner.transform.position.y) {
				myLaneSpawner = spawner;
				return;
			} 
		}
		Debug.LogError ("Can't find spawner!");
	}


	private void Fire(){
		GameObject newProjectile = Instantiate (projectile);

		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
