using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public GameObject card_1 = null;
	public GameObject card_2 = null;
	public GameObject input;
	private string direction;
	private bool hasCalled = false;

	public void Change(GameObject btn){
		if (card_1 == null) {
			card_1 = btn;
			direction = "Front";
		} else if(card_2 == null){
			card_2 = btn;
			direction = "Front";
		}
	}

	void FixAngle(GameObject toFix){
		switch ((int)toFix.transform.localEulerAngles.y) {
		case 179:
			toFix.transform.rotation = Quaternion.Euler (0, 180, 0);
			hasCalled = true;
			break;
			
		case 359:
			toFix.transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		}
	}

	public void Move(){
		if ((card_1 != null) && (card_1.transform.localEulerAngles.y != 180)) {
			Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
			card_1.transform.rotation = Quaternion.Slerp (card_1.transform.rotation, newRotation, 0.1f);
			FixAngle(card_1);
			GetComponent<Card_Content>().Content(card_1);
		}

		if ((card_2 != null) && (card_2.transform.localEulerAngles.y != 180)) {
			Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
			card_2.transform.rotation = Quaternion.Slerp (card_2.transform.rotation, newRotation, 0.1f);
			FixAngle(card_2);
			GetComponent<Card_Content>().Content(card_2);
		} else if (((card_2 != null) && (card_1 != null)) && (card_2.transform.localEulerAngles.y == 180) && (hasCalled)) {
			StartCoroutine(CompareCard());
			hasCalled = false;
		}
	}

	public void MoveBack(){
		if ((card_1 != null) && (card_1.transform.localEulerAngles.y != 0)) {
			Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.up);
			card_1.transform.rotation = Quaternion.Slerp (card_1.transform.rotation, newRotation, 0.1f);
			FixAngle(card_1);
			GetComponent<Card_Content>().Content(card_1);
		}
		
		if ((card_2 != null) && (card_2.transform.localEulerAngles.y != 0)) {
			Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.up);
			card_2.transform.rotation = Quaternion.Slerp (card_2.transform.rotation, newRotation, 0.1f);
			FixAngle(card_2);
			GetComponent<Card_Content>().Content(card_2);
		} else if ((card_2 != null) && (card_2.transform.localEulerAngles.y == 0)) {
			card_1 = null;
			card_2 = null;
			direction = null;
		}
	}

	IEnumerator CompareCard(){
		yield return new WaitForSeconds (.5f);
		if (verify()) {
			Destroy (card_1);
			Destroy (card_2);
			input.GetComponentInChildren<Text>().text = "";
			input.GetComponent<Image>().color = new Color(0,0,0,1);
			direction = null;
		} else {
			direction = "Back";
		}
	}

	bool verify(){
		if (gameObject.GetComponent<CheckMatch> ().check (card_1, card_2))
			return true;	
		
		return false;
	}

	void Update(){
		if (direction == "Front") {
			Move();
		} else if(direction == "Back"){
			MoveBack();
		}

	}

}