using UnityEngine;
using System.Collections;

public class AttackArea : MonoBehaviour {

	public void OnTriggerEnter(Collider c) {
		BaseCharacter parent = transform.parent.GetComponent<BaseCharacter>();

		if(parent != null) {
			parent.AttackOnTriggerEnter(c);
		}
	}


	public void OnTriggerStay(Collider c) {
		BaseCharacter parent = transform.parent.GetComponent<BaseCharacter>();

		if(parent != null) {
			parent.AttackOnTriggerStay(c);
		}
	}


	public void OnTriggerExit(Collider c) {
		BaseCharacter parent = transform.parent.GetComponent<BaseCharacter>();

		if(parent != null) {
			parent.AttackOnTriggerExit(c);
		}
	}
}
