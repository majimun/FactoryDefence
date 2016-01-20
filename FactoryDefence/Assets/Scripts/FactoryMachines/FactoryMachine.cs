using UnityEngine;
using System.Collections;

public class FactoryMachine : BaseCharacter {

	// Use this for initialization
	void Awake () {
		Setup ();
	}


	public override void Setup () {
		//=== ステータス ===//
		_status = new CharacterStatusData();
		_status.Name = "machine";
		_status.Id = "null";
		_status.Attribute = "fire";
		_status.Level = 1;
		_status.Hp_max = 20;
		_status.Hp = _status.Hp_max;
		_status.Exp = 0;
		_status.Exp_max = 5;
		_status.Attack = 0;
		_status.Speed = 0;
		_status.Search_range = 0;
		_status.Attack_renge = 0;
		_status.Energy_rate = 0;


		//=== Transform 設定 ===//
		transform.tag = "Machine";
	}


	void Update () {
		if(_status.Hp <= 0) {
			Debug.Log("!!!Game Over!!!");
		}
	}
}
