using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}

	//Проверяем пора ли спавнить объект
	bool isTimeToSpawn(GameObject attackerGameObject){
		//Запрашиваем доступ к компоненту Attacker объекта
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		//чтоб короче писать определяем отдельную переменную
		float meanSpawnDelay = attacker.seenEverySeconds;
		//Определяем частоту спаунов/сек
		float spawnPerSecond = 1/meanSpawnDelay;

		//Для предупреждения о превышении времени спауна??
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} 

		//Порог спауна с зависимостью от времени отрисовки кадра
		float threshold = spawnPerSecond * Time.deltaTime / 5;

		return (Random.value < threshold);
	}

	void Spawn(GameObject myGameObject){
		GameObject attackerClone = Instantiate (myGameObject);
		attackerClone.transform.parent = transform;
		attackerClone.transform.position = transform.position;
	}
}
