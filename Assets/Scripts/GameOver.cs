using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	private TextMesh gameOverText = null;
	private TextMesh textScore = null;

	public void Awake(){
		gameOverText = GameObject.Find("TxtGameOver").GetComponent<TextMesh>();
		gameOverText.GetComponent<Renderer>().material.color = 
			new Color(gameOverText.GetComponent<Renderer>().material.color.r,
			            gameOverText.GetComponent<Renderer>().material.color.g,
			            gameOverText.GetComponent<Renderer>().material.color.b,
			            0f);

		textScore = GameObject.Find("TxtFinalScore").GetComponent<TextMesh>();
		textScore.text = "Score: " + Scoring.Instance().score;
	}
	
	public void Update() {
		float a = gameOverText.GetComponent<Renderer>().material.color.a;
		if (a != 1) {
			a += Time.deltaTime * .5f;
			if (a > 1)
				a = 1;
			gameOverText.GetComponent<Renderer>().material.color = new Color(
				gameOverText.GetComponent<Renderer>().material.color.r,
				gameOverText.GetComponent<Renderer>().material.color.g,
				gameOverText.GetComponent<Renderer>().material.color.b,
				a
			);
		}
	}

	public void OnClick(string target) {
		switch (target) {
		case "BtnMainMenu" :
			Application.LoadLevel ("MainMenu");
			break;
		case "BtnRetry" :
			Application.LoadLevel ("Gameplay");
			break;
		}
	}
}
