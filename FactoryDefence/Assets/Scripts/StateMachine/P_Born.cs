using UnityEngine;
using System.Collections;

public class P_Born : BaseState {

	// Use this for initialization
	public override void Start () {
		_prof.name = "P_Stay";
		_prof.id = 0;

		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, 100, 0), ForceMode.Acceleration);
		ChangeState(1);
	}
}
