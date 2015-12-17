using UnityEngine;
using System.Collections;

public class PresentToy : BaseCharacter {

	private GameObject _targetEnemy;

	// Use this for initialization
	void Start () {
		// status initialize
		InitStatus ();

		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		transform.tag = "PresentToy";

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
			pos.z += 1.5f * Time.deltaTime;
			transform.position = pos;

			if(_targetEnemy != null) {
				_actionState = ACTION_STATE_LOOK;
			} else {
				GameObject enemy = Search("E_Body");
				if(enemy != null){
					_targetEnemy = enemy;
				}
			}
			break;

		case ACTION_STATE_LOOK:
			if(_targetEnemy != null) {
				transform.LookAt(_targetEnemy.transform);

				pos = transform.position;
				pos += transform.forward * 2.0f * Time.deltaTime;
				transform.position = pos;
			} else {
				_actionState = ACTION_STATE_SEARCH;
			}
			break;

		case ACTION_STATE_ATTACK:
			if(_targetEnemy != null) {
				_targetEnemy.transform.parent.GetComponent<BaseCharacter>().OnDamage(_statusArray[(int)StatusIndex.ATTACK]);
			} else {
				_actionState = ACTION_STATE_SEARCH;
			}
			break;
		}
	}


	public void OnCollisionEnter(Collision c) {
		GameObject hitObj = c.gameObject;

		if (hitObj != null) {
			if (hitObj.transform.tag.Equals ("Enemy")) {
				_actionState = ACTION_STATE_ATTACK;
				//Destroy(hitObj.gameObject);
			}
		}
	}
}
