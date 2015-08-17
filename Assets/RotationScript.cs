using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	private string isRotating = null;
	private GameObject card;

	IEnumerator FixAngle(GameObject toFix){
		switch ((int)toFix.transform.localEulerAngles.y) {
			case 179:
				toFix.transform.rotation = Quaternion.Euler (0, 180, 0);
				isRotating = null;
				yield return new WaitForSeconds (2f);
				isRotating = "Back";
				break;

			case 359:
				toFix.transform.rotation = Quaternion.Euler (0, 0, 0);
				print("Imma here?");
				isRotating = null;
				card = null;
				break;
		}


	}

	public void Move(GameObject btn){
		Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
		btn.transform.rotation = Quaternion.Slerp (btn.transform.rotation, newRotation, 0.1f);
		StartCoroutine(FixAngle(btn));
	}

	public void MoveBack(GameObject btn){
		Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.up);
		btn.transform.rotation = Quaternion.Slerp (btn.transform.rotation, newRotation, 0.1f);
		StartCoroutine(FixAngle(btn));
	}

	public void Change(GameObject btn){
		card = btn;
		isRotating = "Front";
	}

	void Update(){
		if(isRotating == "Front"){
			Move(card);
		} else if(isRotating == "Back"){
			MoveBack(card);
		}
	}
}