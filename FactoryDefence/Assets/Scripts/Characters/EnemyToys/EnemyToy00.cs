using UnityEngine;
using System.Collections;

public class EnemyToy00 : BaseCharacter {

	// Use this for initialization
	void Awake () {
		Setup ();
	}


	public override void Setup () {
		//=== ステータス ===//
		_status = new CharacterStatusData();
		_status.Name = "adv_soldier";
		_status.Id = "null";
		_status.Attribute = "thunder";
		_status.Level = 1;
		_status.Hp_max = 5;
		_status.Hp = _status.Hp_max;
		_status.Exp = 0;
		_status.Exp_max = 5;
		_status.Attack = 5;
		_status.Speed = 1;
		_status.Search_range = 5;
		_status.Attack_renge = 2;
		_status.Energy_rate = 1;

		//=== 衝突判定用オブジェクト ===//
		_searchArea = transform.FindChild ("SearchArea").gameObject;
		_searchArea.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f) * _status.Search_range;
		_attackArea = transform.FindChild ("AttackArea").gameObject;
		_attackArea.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f) * _status.Attack_renge;

		//=== Transform 設定 ===//
		transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		transform.tag = "EnemyToy";
	}

	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		if (_status.Hp <= 0) {
			//_actionState = ACTION_STATE_DEATH;
			Destroy(gameObject);
		}
	}

	public void OnCollisionEnter(Collision c) {
			
	}


	public override void SearchOnTriggerEnter (Collider other) {
		if(other.tag.Equals("PlayerToy") || other.tag.Equals("Machine")) {
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
		if(other.tag.Equals("PlayerToy") || other.tag.Equals("Machine")) {
			if(StateProf.name.Equals("P_Look")) {
				// 攻撃状態へ遷移
				GameObject state = FindChildWithTag("State").gameObject;
				state.GetComponent<BaseState>().ChangeState(3);
			}
		}

		base.AttackOnTriggerEnter (other);
	}
}
