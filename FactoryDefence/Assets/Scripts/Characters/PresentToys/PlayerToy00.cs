using UnityEngine;
using System.Collections;

public class PlayerToy00 : BaseCharacter {
	// Use this for initialization
	void Start () {
		// status initialize
		InitStatus ();

		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		transform.tag = "PlayerToy";

		_actionState = ACTION_STATE_BORN;
	}


	public override void InitStatus () {
		float[] stArray = {1.0f, 10.0f, 1.0f, 0.5f, 1.0f, 5.0f, 1.0f};
		CreateCharacter (stArray);
	}

	
	// Update is called once per frame
	void Update () {
		//=== 毎フレーム初期化 ===//
		Vector3 pos = transform.position;
		SearchFlag = false;
		AttackFlag = false;
		//=====================//

		if (_statusArray[(int)StatusIndex.HP] <= 0) {
			_actionState = ACTION_STATE_DEATH;
			Destroy(gameObject);
		}

		if(transform.FindChild("P_Attack") != null) {
			Debug.Log("attack!!!");
		}

		switch (StateProf.name) {
		case "P_Born":
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0), ForceMode.Acceleration);
			_actionState = ACTION_STATE_SEARCH;
			break;

		case "P_Stay":
			break;

		case "P_Search":
			
			break;

		case "P_Look":
			/*
			if(_target != null) {
				transform.LookAt(_target.transform);

				pos = transform.position;
				pos += transform.forward * 2.0f * Time.deltaTime;
				transform.position = pos;
			} else {
				_actionState = ACTION_STATE_SEARCH;
			}
			*/
			break;

		case "P_Attack":
			
			/*
			if(_target != null) {
				_target.GetComponent<BaseCharacter>().OnDamage(_statusArray[(int)StatusIndex.ATTACK]);
			} else {
				_actionState = ACTION_STATE_SEARCH;
			}
			*/
			break;
		}
	}


	public void OnCollisionEnter(Collision c) {
		GameObject hitObj = c.gameObject;

		if (hitObj != null) {
			if (hitObj.transform.tag.Equals ("EnemyToy")) {
				_actionState = ACTION_STATE_ATTACK;
				//Destroy(hitObj.gameObject);
			}
		}
	}


	public override void SearchOnTriggerEnter (Collider other) {
		if(other.tag.Equals("EnemyToy")) {
			if(StateProf.name.Equals("P_Search")) {
				for(int i = 0; i < transform.childCount; i++) {
					if(transform.GetChild(i).tag.Equals("State")) {
						Target = other.gameObject;
						transform.GetChild(i).GetComponent<BaseState>().ChangeState(2);

						break;
					}
				}
			}
		}

		base.SearchOnTriggerEnter (other);
	}


	public override void AttackOnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("EnemyToy")) {
			if(StateProf.name.Equals("P_Look")) {
				for(int i = 0; i < transform.childCount; i++) {
					if(transform.GetChild(i).tag.Equals("State")) {
						Target = other.gameObject;
						transform.GetChild(i).GetComponent<BaseState>().ChangeState(3);

						break;
					}
				}
			}
		}

		base.AttackOnTriggerEnter (other);
	}
}
