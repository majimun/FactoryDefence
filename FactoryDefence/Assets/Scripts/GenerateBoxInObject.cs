using UnityEngine;
using System.Collections;

public class GenerateBoxInObject : MonoBehaviour {

    public GameObject InObject;     // 出現させるオブジェクト

    // 出現時初期化メソッド
    void Start () {
	    
	}

	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0)) {
            Debug.Log("generate box");
        }
	}
}
