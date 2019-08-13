using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

	GameObject mainLogo = null;
	
	// Use this for initialization
	void Awake () {
		mainLogo = GameObject.Find("MainLogo");
		mainLogo.transform.localPosition = new Vector3(mainLogo.transform.position.x, 600f, mainLogo.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		/*
		mainLogo.transform.localPosition = new Vector3(
			0f, 
			Mathf.MoveTowards(mainLogo.transform.localPosition.y, 200f, Time.deltaTime * 500f),
			0.5f
		);
		*/
		mainLogo.transform.localPosition = new Vector3(
			mainLogo.transform.localPosition.x, 
			Mathf.Lerp(mainLogo.transform.localPosition.y, 200f, Time.deltaTime * 2f),
			mainLogo.transform.localPosition.z
		);
	}

	public void OnClick(string target) {
		switch (target) {
		case "BtnPlay" :
			Application.LoadLevel ("Gameplay");
			break;
		}
	}
}
