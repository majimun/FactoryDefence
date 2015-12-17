using UnityEngine;
using System.Collections;

public class FactoryMachine : MonoBehaviour {
	
	private float _hpMax;
	private float _hp;

	// Use this for initialization
	void Start () {
		_hpMax = 10;
		_hp = _hpMax;
	}
	
	// Update is called once per frame
	void Update () {
		if (_hp <= 0) {
			Debug.Log("Game Over");
		}
	}


	public void OnCollisionEnter (Collision c) {
		if (c.transform.tag.Equals ("Enemy")) {
			_hp--;
		}
	}
}
