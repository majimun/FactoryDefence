using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	public GameObject Enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 120 == 0) {
			Vector3 initPos = Vector3.zero;
			initPos.x = Random.Range(-2.5f, 2.5f);
			initPos.y = 1.0f;
			initPos.z = 10.0f;

			GameObject enemyClone = (GameObject)Instantiate(Enemy, initPos, Quaternion.identity);
		}
	}
}
