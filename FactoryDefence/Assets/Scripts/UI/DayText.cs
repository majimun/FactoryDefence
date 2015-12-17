using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayText : MonoBehaviour {

	Text _dayTxt;
	
	// Use this for initialization
	void Start () {
		_dayTxt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		int currentDay = CalendarManager.Instance.Day;
		string dayStr = "Day " + currentDay;
		
		_dayTxt.text = dayStr;
	}
}
