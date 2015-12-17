using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager> {

	private bool _isCollector;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int day = CalendarManager.Instance.Day;

		if (day % 10 == 0 && day != 0) {
			if (_isCollector == false) {
				int score = ScoreManager.Instance.Score;
				score -= 1500;
				ScoreManager.Instance.ScoreEdit (score);


				if (score < 0) {
					Debug.Log ("Game Over");
				}

				_isCollector = true;
			}
		} else {
			_isCollector = false;
		}

		if(day % 100 == 0 && day != 0) {
			Debug.Log("Game Clear");
		}
	}
}
