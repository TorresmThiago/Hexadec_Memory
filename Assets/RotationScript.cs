using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	private GameObject card_1 = null;
	private GameObject card_2 = null;
	private string direction;

	//Funçao chamada ao clique do button
	public void Change(GameObject btn){
		if (card_1 == null) {
			card_1 = btn;
		} else if(card_2 == null){
			card_2 = btn;
		}

		direction = "Front";
	}

	void FixAngle(GameObject toFix){
		switch ((int)toFix.transform.localEulerAngles.y) {
		case 179:
			toFix.transform.rotation = Quaternion.Euler (0, 180, 0);
			break;
			
		case 359:
			toFix.transform.rotation = Quaternion.Euler (0, 0, 0);
			break;
		}
	}
	
	//Funçao que necessariamente move as cartas
	public void Move(){
		if ((card_1 != null) && (card_1.transform.localEulerAngles.y != 180)) {
			Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
			card_1.transform.rotation = Quaternion.Slerp (card_1.transform.rotation, newRotation, 0.1f);
			FixAngle(card_1);
		}

		if ((card_2 != null) && (card_2.transform.localEulerAngles.y != 180)) {
			Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
			card_2.transform.rotation = Quaternion.Slerp (card_2.transform.rotation, newRotation, 0.1f);
			FixAngle(card_2);
		} else if ((card_2 != null) && (card_2.transform.localEulerAngles.y == 180)) {
			StartCoroutine(CompareCard());
			print("I'm here");
		}
	}

	//Funçao que necessariamente move as cartas de volta
	public void MoveBack(){
		if ((card_1 != null) && (card_1.transform.localEulerAngles.y != 0)) {
			Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.up);
			card_1.transform.rotation = Quaternion.Slerp (card_1.transform.rotation, newRotation, 0.1f);
			FixAngle(card_1);
		}
		
		if ((card_2 != null) && (card_2.transform.localEulerAngles.y != 0)) {
			Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.up);
			card_2.transform.rotation = Quaternion.Slerp (card_2.transform.rotation, newRotation, 0.1f);
			FixAngle(card_2);
		} else if ((card_2 != null) && (card_2.transform.localEulerAngles.y == 0)) {
			card_1 = null;
			card_2 = null;
			direction = null;
		}
	}

	//Da a simpatica esperada e depois volta(ou nao)
	IEnumerator CompareCard(){
		yield return new WaitForSeconds (1);
		if (verify()) {
			//Implementar fadeOut
			Destroy (card_1);
			Destroy (card_2);
		} else {
			direction = "Back";
		}
	}

	//ve se as cartas tem o mesmo codigohex
	bool verify(){
		if (gameObject.GetComponent<CheckMatch> ().check (card_1, card_2))
			return true;	
		
		return false;
	}
	
	//Update. Necessario para a atualizaçao visual da rotaçao
	void Update(){
		if (direction == "Front") {
			Move();
		} else if(direction == "Back"){
			MoveBack();
		}
	}

}