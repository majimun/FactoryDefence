using UnityEngine;
using System.Collections;

//+++ PlayerToy = 探索状態[ID: 1] +++//
public class P_Search : BaseState {

	// Use this for initialization
	void Start () {
		_prof.name = "P_Search";
		_prof.id = 1;

		NameLog();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.parent.position;
		pos.z += 1.5f * Time.deltaTime;
		transform.parent.position = pos;
		transform.parent.rotation = Quaternion.Euler(0, 0, 0);

		// 敵を探知すると追尾状態に遷移
		if(transform.parent.GetComponent<BaseCharacter>().SearchFlag == true) {
			ChangeState(2);
		}

		Debug.Log("" + transform.parent.GetComponent<BaseCharacter>().SearchFlag);
	}
}
