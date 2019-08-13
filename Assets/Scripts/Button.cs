using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject target;

	public void OnMouseUpAsButton() {
		if (target == null)
			return;

		target.SendMessage ("OnClick", gameObject.name, SendMessageOptions.DontRequireReceiver);
	}
}
