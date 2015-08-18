using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	private string isRotating = null;
	private GameObject card;
	private GameObject card_2;


	void FixAngle(GameObject toFix){
		switch ((int)toFix.transform.localEulerAngles.y) {
			case 179:
				toFix.transform.rotation = Quaternion.Euler (0, 180, 0);
				//isRotating = null;
				//card = null;
				break;

			case 359:
				toFix.transform.rotation = Quaternion.Euler (0, 0, 0);
				isRotating = null;
				//card = null;
				break;
		}
	}

	public void Move(GameObject btn){
		Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
		btn.transform.rotation = Quaternion.Slerp (btn.transform.rotation, newRotation, 0.1f);
		FixAngle (btn);
	}

	public void MoveBack(GameObject btn){
		Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.up);
		btn.transform.rotation = Quaternion.Slerp (btn.transform.rotation, newRotation, 0.1f);
		FixAngle (btn);
	}

	public void Change(GameObject btn){
		if (card == null) {
			card = btn;
		} else {
			card_2 = btn;
		}

		isRotating = "Front";
	}

	bool verify(GameObject btn_a, GameObject btn_b){
		if (gameObject.GetComponent<CheckMatch> ().check (btn_a, btn_b)) {
			return true;	
		}

		return false;
	}

	void Update(){
		if(isRotating == "Front"){
			Move(card);
			if(card_2 != null)
				Move(card_2);
		} else if(isRotating == "Back"){
			MoveBack(card);
		}
	}
}