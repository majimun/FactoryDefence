using UnityEngine;
using System.Collections;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> {

	private int _score;
	private int _highScore;


	public int Score {
		get { return _score; }
	}

	public int HighScore {
		get { return _highScore; }
	}


	public void ScoreEdit (int score) {
		_score = score;

		if (_score > _highScore) {
			_highScore = score;
		}
	}


	public void ScoreReset () {
		_score = 0;
		_highScore = 0;
	}
}
