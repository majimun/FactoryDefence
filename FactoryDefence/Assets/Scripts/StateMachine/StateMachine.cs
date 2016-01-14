using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine : MonoBehaviour {

	public GameObject[] States;


	// Use this for initialization
	void Start () {
		// 初期起動
		Execute(0);
	}


	public void Execute (int id) {
		// 元から状態がある場合は、状態を終了させる
		for(int i = 0; i < transform.childCount; i++) {
			if(transform.GetChild(i).tag.Equals("State")) {
				transform.GetChild(i).GetComponent<BaseState>().Finish();
			}
		}

		GameObject state = (GameObject)Instantiate(States[id], Vector2.zero, Quaternion.identity);
		state.transform.parent = transform;
		state.transform.position = Vector2.zero;
		state.GetComponent<BaseState>().Execute();
	}
}
