﻿using UnityEngine;
using System.Collections;

//+++ PlayerToy = 攻撃状態[ID: 3] +++//
public class P_Attack : BaseState {

	private GameObject _target;

	// Use this for initialization
	void Start () {
		_prof.name = "P_Attack";
		_prof.id = 3;

		NameLog();
		transform.parent.GetComponent<BaseCharacter>().StateProf = _prof;
		_target = transform.parent.GetComponent<BaseCharacter>().Target;
	}
	
	// Update is called once per frame
	void Update () {
		if(_target != null) {
			transform.parent.GetComponent<BaseCharacter>().Attack(_target);
		} else {
			ChangeState(1);
		}
	}
}
