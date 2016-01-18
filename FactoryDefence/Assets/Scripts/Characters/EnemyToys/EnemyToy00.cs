using UnityEngine;
using System.Collections;

public class EnemyToy00 : BaseCharacter {

	// Use this for initialization
	void Start () {
		InitStatus ();

		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		transform.tag = "EnemyToy";

		_prof.name = transform.name;
		_prof.tag = transform.tag;
	}


	public override void InitStatus () {
		float[] stArray = {1.0f, 10.0f, 1.0f, 1.0f, 2.0f, 5.0f, 1.0f};
		CreateCharacter (stArray);
	}

	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if (_statusArray[(int)StatusIndex.HP] <= 0) {
			_actionState = ACTION_STATE_DEATH;
			Destroy(gameObject);
		}		
	}

	public void OnCollisionEnter(Collision c) {
			
	}


	public override void SearchOnTriggerEnter (Collider other) {
		if(other.tag.Equals("Machine") || other.tag.Equals("PlayerToy")) {
			if(StateProf.name.Equals("P_Search")) {
				Target = other.gameObject;

				// 追尾状態へ遷移
				GameObject state = FindChildWithTag("State").gameObject;
				state.GetComponent<BaseState>().ChangeState(2);
			}
		}

		base.SearchOnTriggerEnter (other);
	}


	public override void AttackOnTriggerEnter (Collider other)
	{
		if(other.tag.Equals("PlayerToy")) {
			if(StateProf.name.Equals("P_Look")) {
				// 攻撃状態へ遷移
				GameObject state = FindChildWithTag("State").gameObject;
				state.GetComponent<BaseState>().ChangeState(3);
			}
		}

		base.AttackOnTriggerEnter (other);
	}
}
