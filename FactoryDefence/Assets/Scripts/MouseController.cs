using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit rayHit = new RaycastHit();

			if(Physics.Raycast(mouseRay, out rayHit)) {
				if(rayHit.collider.gameObject != null) {
					GameObject hitObj = rayHit.collider.gameObject;
					if(hitObj != null) {
						Debug.Log(""+ hitObj.name);
					}

					if(hitObj.tag.Equals("Box")) {
						hitObj.GetComponent<GenerateBoxInObject>().GeneratEvent();
					}
				}
			}
		}
	}
}
