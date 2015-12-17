using UnityEngine;
using System.Collections;

public class Enemy : BaseCharacter {

	// Use this for initialization
	void Start () {
		InitStatus ();

		transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
		transform.tag = "Enemy";

		_actionState = ACTION_STATE_STAY;
	}


	public override void InitStatus () {
		float[] stArray = {1.0f, 10.0f, 1.0f, 1.0f, 1.0f, 5.0f, 1.0f};
		CreateCharacter (stArray);
	}

	
	// Update is called once per frame
	void Update () {
		if (_statusArray[(int)StatusIndex.HP] <= 0) {
			_actionState = ACTION_STATE_DEATH;
			Destroy(gameObject);
		}

		Vector3 pos = transform.position;
		pos.z -= 1.0f * Time.deltaTime;
		transform.position = pos;
	}

	public void OnCollisionEnter(Collision c) {
		if(c.transform.tag.Equals("ToyMachine")) {
			Destroy(gameObject);
		}
	}
}
