using UnityEngine;
using System.Collections;

public class BoxGenerator : MonoBehaviour {

	public GameObject Present;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 60 == 0) {
			Vector3 initPos = Vector3.zero;
			initPos.x = transform.position.x;
			initPos.y = transform.position.y + 0.5f;
			initPos.z = transform.position.z;

			GameObject presentClone = (GameObject)Instantiate(Present, initPos, Quaternion.identity);
		}
	}
}
