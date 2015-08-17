using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	/*public void HelloWord (GameObject btn) {
		print (btn.GetComponentInChildren<Text>().text);
	}*/

	private bool isRotating = false;
	private GameObject card;

	IEnumerator FixAngle(GameObject toFix){
		switch ((int)toFix.transform.localEulerAngles.y) {
			case 179:
				toFix.transform.rotation = Quaternion.Euler (0, 180, 0);
				isRotating = false;
				card = null;
				break;
		}

		yield return new WaitForSeconds (1f);
	}

	public void Move(GameObject btn){
		Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
		btn.transform.rotation = Quaternion.Slerp (btn.transform.rotation, newRotation, 0.1f);
		StartCoroutine(FixAngle(btn));
	}

	public void Change(GameObject btn){
		card = btn;
		isRotating = true;
	}

	void Update(){
		if(isRotating){
			Move(card);
		}
	}
}