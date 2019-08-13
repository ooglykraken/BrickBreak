using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public int score = 0;

	private static Scoring instance = null;
	public static Scoring Instance() {
		if (instance == null) {
			instance = (new GameObject("Scoring")).AddComponent<Scoring>();
			DontDestroyOnLoad(instance.gameObject);
		}
		return instance;
	}
}
