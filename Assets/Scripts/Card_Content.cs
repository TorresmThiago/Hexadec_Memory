using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card_Content : MonoBehaviour {

	private string tempClr;
	public Sprite cardImg;
	public Sprite ctnImg;

	public void Content(GameObject btn){

		string crdCode = btn.GetComponentInChildren<Text> ().text;

		if (crdCode[0] == 'C') {


			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar

				for(int i = 0; i < Clrs.Count; i++){

					int r = (int)Mathf.Floor(Clrs[i].r * 255);
					int g = (int)Mathf.Floor(Clrs[i].g * 255);
					int b = (int)Mathf.Floor(Clrs[i].b * 255);
					string toShow = "C" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");

					if(toShow == crdCode){
						btn.GetComponent<Image>().color = Clrs[i];
						btn.GetComponent<Image>().sprite = ctnImg;
					}
				}
			}
			
			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				btn.GetComponent<Image>().color = new Color(1,1,1,1);
				btn.GetComponent<Image>().sprite = cardImg;
			}

		} else if (crdCode[0] == '#') {
		
			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				btn.GetComponentInChildren<Text>().enabled = true;
				btn.GetComponent<Button>().enabled = false;
				btn.GetComponent<Image>().sprite = ctnImg;
				btn.GetComponent<Image>().color = new Color(0,0,0,1);
			
			}

			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				btn.GetComponentInChildren<Text>().enabled = false;
				btn.GetComponent<Button>().enabled = true;
				btn.GetComponent<Image>().sprite = cardImg;
				btn.GetComponent<Image>().color = new Color(1,1,1,1);
			}
		}
	}
}