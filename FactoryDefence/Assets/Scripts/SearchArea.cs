using UnityEngine;
using System.Collections;

public class SearchArea : MonoBehaviour {


	public void OnTriggerEnter(Collider c) {
		BaseCharacter parent = transform.parent.GetComponent<BaseCharacter>();

		if(parent != null) {
			parent.SearchOnTriggerEnter(c);
		}
	}


	public void OnTriggerStay(Collider c) {
		BaseCharacter parent = transform.parent.GetComponent<BaseCharacter>();

		if(parent != null) {
			parent.SearchOnTriggerStay(c);
		}
	}


	public void OnTriggerExit(Collider c) {
		BaseCharacter parent = transform.parent.GetComponent<BaseCharacter>();

		if(parent != null) {
			parent.SearchOnTriggerExit(c);
		}
	}
}
