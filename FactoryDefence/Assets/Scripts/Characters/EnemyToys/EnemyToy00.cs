using UnityEngine;
using System.Collections;

public class EnemyToy00 : BaseCharacter {

	// Use this for initialization
	void Start () {
		InitStatus ();

		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		transform.tag = "EnemyToy";

		_actionState = ACTION_STATE_BORN;
	}


	public override void InitStatus () {
		float[] stArray = {1.0f, 10.0f, 1.0f, 1.0f, 1.0f, 5.0f, 1.0f};
		CreateCharacter (stArray);
	}

	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if (_statusArray[(int)StatusIndex.HP] <= 0) {
			_actionState = ACTION_STATE_DEATH;
			Destroy(gameObject);
		}
			
		switch (_actionState) {
		case ACTION_STATE_BORN:
			GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0), ForceMode.Acceleration);
			_actionState = ACTION_STATE_SEARCH;
			break;

		case ACTION_STATE_STAY:
			break;

		case ACTION_STATE_SEARCH:
			pos = transform.position;
			pos.z -= 1.0f * Time.deltaTime;
			transform.position = pos;
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
			if(_target != null) {
				_target.GetComponent<BaseCharacter>().OnDamage(_statusArray[(int)StatusIndex.ATTACK]);
			} else {
				_actionState = ACTION_STATE_SEARCH;
			}
			break;
		}
	}

	public void OnCollisionEnter(Collision c) {
		if(c.transform.tag.Equals("Machine")) {
			//Destroy(gameObject);
		}
	}


	public override void SearchOnTriggerEnter (Collider other) {
		if(other.tag.Equals("Machine") || other.tag.Equals("PlayerToy")) {
			if(_actionState == ACTION_STATE_SEARCH) {
				_actionState = ACTION_STATE_LOOK;
				_target = other.gameObject;
			}
		}

		base.SearchOnTriggerEnter (other);
	}
}
