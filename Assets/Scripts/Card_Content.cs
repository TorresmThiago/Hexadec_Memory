using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card_Content : MonoBehaviour {

	private List<Color> Clrs = new List<Color>();

	public void GetColor(Color clr){
		Clrs.Add (clr);	
	}

	public void Content(GameObject btn){

		string crdCode = btn.GetComponentInChildren<Text> ().text;


		if (crdCode[2] == 'l') {

			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				crdCode = crdCode.Substring(3);

				for(int i = 0; i < Clrs.Count; i++){
					if(Clrs[i].ToString() == crdCode)
					btn.GetComponent<Image>().color = Clrs[i];
				}


			}
			
			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				//print("Nao Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = false;
			}

		} else if (crdCode[2] == 'd') {
		
			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				//print("Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = true;
			}

			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				//print("Nao Estou mostrando");
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = false;
			}

		}
	}
}
