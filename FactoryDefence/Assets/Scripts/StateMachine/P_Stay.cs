﻿using UnityEngine;
using System.Collections;

//+++ PlayerToy = 停止状態[ID: 0] +++//
public class P_Stay : BaseState {
	

	// Use this for initialization
	public override void Start () {
		_prof.name = "P_Stay";
		_prof.id = 0;

		base.Start ();
	}
	

	void Update () {
		int time = Time.frameCount;
		if(time % 60 == 0 && time != 0) {
			ChangeState(1);
		}
	}
}
