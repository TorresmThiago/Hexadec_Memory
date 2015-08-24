using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card_Content : MonoBehaviour {

	public void Content(GameObject btn){

		string crdCode = btn.GetComponentInChildren<Text> ().text;

		if (crdCode[2] == 'l') {
		
			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				print("Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = true;
			}
			
			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				print("Nao Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = false;
			}

		} else if (crdCode[2] == 'd') {
		
			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				print("Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = true;
			}

			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				print("Nao Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = false;
			}

		}
	}
}
