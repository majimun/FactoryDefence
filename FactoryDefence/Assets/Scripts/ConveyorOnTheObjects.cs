using UnityEngine;
using System.Collections;

public class ConveyorOnTheObjects : MonoBehaviour {

    // 接触しているキャラクタを左から右へ流す
    public void OnCollisionStay(Collision other) {
        if(other.gameObject.tag.Equals("Box")) {
            Vector3 pos = other.transform.position;
            pos += transform.right * Time.deltaTime * 1.0f;
            other.transform.position = pos;
        }
    }
}
