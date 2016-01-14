using UnityEngine;
using System.Collections;

//+++ PlayerToy = 攻撃状態[ID: 3] +++//
public class P_Attack : BaseState {

	// Use this for initialization
	void Start () {
		_prof.name = "P_Attack";
		_prof.id = 3;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(_target != null) {
			_target.GetComponent<BaseCharacter>().OnDamage(_statusArray[(int)StatusIndex.ATTACK]);
		} else {
			_actionState = ACTION_STATE_SEARCH;
		}
		*/
	}
}
