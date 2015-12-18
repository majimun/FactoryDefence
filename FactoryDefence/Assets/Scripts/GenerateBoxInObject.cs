using UnityEngine;
using System.Collections;

public class GenerateBoxInObject : MonoBehaviour {

    public GameObject InObject;     // 出現させるオブジェクト

    // 出現時初期化メソッド
    void Start () {
	    
	}

	
	// Update is called once per frame
	void Update () {
	}


	public void GeneratEvent() {
		Vector3 initPos = Vector3.zero;
		initPos.x = transform.position.x;
		//initPos.y = transform.position.y - 0.5f;
		initPos.z = transform.position.z + 1.0f;

		GameObject toyClone = (GameObject)Instantiate (InObject, transform.position, Quaternion.identity);

		int score = ScoreManager.Instance.Score;
		ScoreManager.Instance.ScoreEdit(score - 5);

		Destroy (gameObject);
	}
}
