using UnityEngine;
using System.Collections;

public struct StateProfile {
	public string name;
	public int id;
}

public class BaseState : MonoBehaviour {

	protected StateProfile _prof;
	protected CharaProfile _charaProf;
	protected Animator _anim;
	protected bool _execute;

	public StateProfile Profile {
		get { return _prof; }
	}

	void Awake () {
		_execute = false;
	}


	public virtual void Start () {
		NameLog();
		transform.parent.GetComponent<BaseCharacter>().StateProf = _prof;
		_charaProf = transform.parent.GetComponent<BaseCharacter>().CharaProf;

	}


	public virtual void Execute () {
		_execute = true;
	}


	public virtual void Finish () {
		_execute = false;
		Destroy( gameObject );
	}


	public virtual void ChangeState (int id) {
		transform.parent.GetComponent<StateMachine>().Execute(id);
	}


	protected void NameLog () {
		Debug.Log("state.name[ " + _prof.name + " ]");
	}
}
