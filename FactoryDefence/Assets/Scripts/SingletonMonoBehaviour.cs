using UnityEngine;
using System.Collections;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

	public static T _instance;

	public static T Instance {
		get { 
			if (_instance == null) {
				_instance = (T)FindObjectOfType (typeof(T));

				if (_instance == null) {
					Debug.LogError ("'" + typeof(T) + "' is nothing");
				}
			}

			return _instance;
		}
	}
}
