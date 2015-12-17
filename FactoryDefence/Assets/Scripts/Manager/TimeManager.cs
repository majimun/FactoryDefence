using UnityEngine;
using System.Collections;

public class TimeManager : SingletonMonoBehaviour<TimeManager> {

	public float BaseSecondFrame;
	private float _time;
	private float _frame;


	public float PlayFrame {
		get { return _frame; }
	}

	public float PlayTime {
		// time / second
		get { return _time; }
	}


	//=== Other Method ===//
	public void ResetAll () {
		_frame = 0;
		_time = 0;
	}

	public void ResetFrame () {
		_frame = 0;
	}

	public void ResetTime () {
		_time = 0;
	}

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		_frame += 1.0f - Time.deltaTime;
		if ((int)_frame % BaseSecondFrame == 0 && (int)_frame != 0) {
			_time++;
		}

		//Debug.Log ("Frame: " + _frame + ", Time: " + _time);
	}
}
