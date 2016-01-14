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

		switch (_actionState) {
		case ACTION_STATE_BORN:
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0), ForceMode.Acceleration);
			_actionState = ACTION_STATE_SEARCH;
			break;

		case ACTION_STATE_STAY:
			break;

		case ACTION_STATE_SEARCH:
			/*
			pos = transform.position;
			pos.z += 1.5f * Time.deltaTime;
			transform.position = pos;
			transform.rotation = Quaternion.Euler(0, 0, 0);
			*/
			break;

		case ACTION_STATE_LOOK:
			if(_target != null) {
				transform.LookAt(_target.transform);

				pos = transform.position;
				pos += transform.forward * 2.0f * Time.deltaTime;
				transform.position = pos;
			} else {
				_actionState = ACTION_STATE_SEARCH;
			}
			break;

		case ACTION_STATE_ATTACK:
			
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
			// 探索状態のフラグを ON にする
			SearchFlag = true;
		}

		base.SearchOnTriggerEnter (other);
	}


	public override void AttackOnTriggerEnter (Collider other)
	{
		if(other.tag.Equals("EnamyToy")) {
			// 攻撃状態のフラグを ON にする
			AttackFlag = true;
		}

		base.AttackOnTriggerEnter (other);
	}
}
