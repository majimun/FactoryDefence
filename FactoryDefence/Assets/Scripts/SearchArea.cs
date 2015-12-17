using UnityEngine;
using System.Collections;

public class SearchArea : MonoBehaviour {

	private GameObject _obj;
	
	public GameObject GetHitObj {
		get{ return _obj; }
	}

	public void OnTriggerEnter(Collider c) {
		_obj = c.gameObject;
	}


	public void OnTriggerStay(Collider c) {
		_obj = c.gameObject;
	}


	public void OnTriggerExit(Collider c) {
		//_obj = null;
	}
}
