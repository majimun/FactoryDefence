using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

	Text _scoreTxt;

	// Use this for initialization
	void Start () {
		_scoreTxt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		int currentScore = ScoreManager.Instance.Score;
		string scoreStr = "Score: " + currentScore;

		if (currentScore < 0) {
			_scoreTxt.color = Color.red;
		} else {
			_scoreTxt.color = Color.black;
		}

		_scoreTxt.text = scoreStr;
	}
}
