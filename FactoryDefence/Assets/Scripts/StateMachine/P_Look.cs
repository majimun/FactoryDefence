using UnityEngine;
using System.Collections;

//+++ PlayerToy = 追尾状態[ID: 2] +++//
public class P_Look : BaseState {

	private GameObject _target;

	// Use this for initialization
	public override void Start () {
		_prof.name = "P_Look";
		_prof.id = 2;

		_target = transform.parent.GetComponent<BaseCharacter>().Target;

		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		if(_target != null) {
			transform.parent.LookAt(_target.transform);

			Vector3 pos = transform.parent.position;
			pos += transform.parent.forward * 2.0f * Time.deltaTime;
			transform.parent.position = pos;
		} else {
			ChangeState(1);
		}
	}
}
