using UnityEngine;
using System.Collections;

public class CalendarManager : SingletonMonoBehaviour<CalendarManager> {

	public const int  WORLD_TIME_BASE = 1;
	private int _second;
	private int _minute;
	private int _hour;
	private int _day;
	private int _month;
	private int _year;


	public int Second {
		get { return _second; }
	}

	public int Minute {
		get { return _minute; }
	}

	public int Hour {
		get { return _hour; }
	}

	public int Day {
		get { return _day; }
	}

	public int Month {
		get { return _month; }
	}

	public int Year {
		get { return _year; }
	}


	// Use this for initialization
	void Start () {
		_second = 0;
		_minute = 0;
		_hour = 0;
		_day = 1;
		_month = 0;
		_year = 1;
	}
	
	// Update is called once per frame
	void Update () {
		_second = (int)TimeManager.Instance.PlayTime;

		if (_second %  WORLD_TIME_BASE == 0 && _second != 0) {
			_minute++;

			// reset GameTime.
			TimeManager.Instance.ResetTime ();
		}

		if (_minute %  WORLD_TIME_BASE == 0 && _minute != 0) {
			_hour++;

			_minute = 0;
		}

		if (_hour % 24 == 0 && _hour != 0) {
			_day++;

			_hour = 0;
		}


		//Debug.Log ("Day: " + _day + " Time[ " + _hour + ":" + _minute + ":" + _second + "]");
	}
}
