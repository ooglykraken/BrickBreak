using UnityEngine;
using System.Collections;

public class MovePaddle : MonoBehaviour {
	
	private BoxCollider Paddle;
	private GameObject Extension;
	

	void Awake(){
		Extension = GameObject.Find ("Paddle");
	}
	
	//Fixed update instead of Update so it's independent of frames
	void FixedUpdate () {

		PaddleShrink();

		if (Input.GetMouseButton(0)) {
			Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			target.y = GetComponent<Rigidbody>().position.y;
			target.z = GetComponent<Rigidbody>().position.z;
			
			GetComponent<Rigidbody>().velocity = new Vector3(
				(target.x - GetComponent<Rigidbody>().position.x) * 10f,//Mathf.Lerp(rigidbody.velocity.x, (target.x - rigidbody.position.x) * 10f, Time.deltaTime * 1000f),
				0,
				0
				);
		}
		else {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
	}

	public void PaddleExtend(){

		if(Extension.transform.localScale.x < 4.9){

		Extension.transform.localScale = 
			new Vector3(Extension.transform.localScale.x + .13f, 
			            Extension.transform.localScale.y, 
			            Extension.transform.localScale.z);
		}
	}
	
	private void PaddleShrink(){
		if(Extension.transform.localScale.x > 1)
		{

			Extension.transform.localScale = 
				new Vector3(Extension.transform.localScale.x - .005f, //Mathf.MoveTowards (Extension.transform.localScale.x, 1.0f,Time.deltaTime), 
				            Extension.transform.localScale.y, 
				            Extension.transform.localScale.z);
		}else if(Extension.transform.localScale.x < 1f){
			Extension.transform.localScale = new Vector3(1f, Extension.transform.localScale.y, Extension.transform.localScale.z);
		}
	}
	
	private static MovePaddle instance = null;
	
	public static MovePaddle Instance() {
		if (instance == null)
			instance = GameObject.FindObjectOfType<MovePaddle> ();
		return instance;
	}
}

