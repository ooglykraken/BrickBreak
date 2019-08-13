using UnityEngine;
using System.Collections;

public class Gameplay: MonoBehaviour {

	private int score = 0;
	private TextMesh txtScore = null;
	private int stage = 1;

	void Awake () {
		Scoring.Instance().score = 0;

		NewStage ();

		txtScore = GameObject.Find ("TxtScore").GetComponent<TextMesh> ();
		RenderScore ();
	}

	public void OnStageComplete(){
		stage ++;
		//Debug.Log (stage);
		if (stage > 3) {
			Application.LoadLevel ("GameOver");
		}
		else {
			StartCoroutine(DelayNewStage());
		}
	}

	private IEnumerator DelayNewStage() {
		yield return new WaitForSeconds (1);
		
		NewStage ();
	}

	public void NewStage(){
		
		int rows = 3;
		int cols = 8;

		switch(stage){
		case 1:
			rows = 3;
			cols = 8;
			break;
		case 2:
			rows = 4;
			cols = 8;
			break;
		case 3:
			rows = 4;
			cols = 10;
			break;
		}
		
		GameObject resource = Resources.Load ("Block", typeof(GameObject)) as GameObject;
		Transform parent = transform.Find ("Blocks");
		
		int[][] level = new int[rows][];
	
		Vector3 spacing = new Vector3(1.25f, .75f, 0f);
		Vector3 position = Vector3.zero;

		parent.position = new Vector3(0, 3, 10f);
		
		for(int i = 0; i < level.Length; i++){
			level[i] = new int[cols];
			for(int j = 0; j < level[i].Length; j++){
				
				int value = Random.Range (0, 2);
				if (j > 0 && level[i][j - 1] == 0) {
					value = 1;
				}
				level[i][j] = value;
				
				position = new Vector3(spacing.x * (float)j, -spacing.y * (float)i, 0f);
				
				if (value != 1)
					continue;
				
				GameObject obj = Instantiate (resource) as GameObject;
				obj.transform.parent = parent;
				obj.name = "Block";
				obj.transform.localPosition = position;
				

			}

		}

		parent.position += new Vector3(
			position.x * -.5f,
			position.y * -.5f,
			0f
		);

		BallMotion.Instance().ResetBlocks();
	}
	
	public void OnScore() {
		score ++;
		Scoring.Instance().score = score;
		RenderScore ();
	}
	
	private void RenderScore() {
		txtScore.text = "Score: " + score.ToString();
	}
	

	private static Gameplay instance = null;
	public static Gameplay Instance() {
		if (instance == null)
			instance = GameObject.FindObjectOfType<Gameplay> ();
		return instance;
	}


}