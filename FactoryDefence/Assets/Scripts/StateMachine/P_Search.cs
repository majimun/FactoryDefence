using UnityEngine;
using System.Collections;

//+++ PlayerToy = 探索状態[ID: 1] +++//
public class P_Search : BaseState {

	// Use this for initialization
	public override void Start () {
		_prof.name = "P_Search";
		_prof.id = 1;

		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.parent.position;

		switch (_charaProf.tag) {
		case "PlayerToy":
			
			pos.z += 1.5f * Time.deltaTime;
			transform.parent.position = pos;
			transform.parent.rotation = Quaternion.Euler(0, 0, 0);
			break;

		case "EnemyToy":
			pos.z -= 1.5f * Time.deltaTime;
			transform.parent.position = pos;
			transform.parent.rotation = Quaternion.Euler(0, 180, 0);
			break;
		}
	}
}
