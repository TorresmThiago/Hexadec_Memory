using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card_Content : MonoBehaviour {

	private string tempClr;
	public Sprite cardImg;
	public Sprite ctnImg;

	private float returnToColor(string clrHex){
		
		int num = Convert.ToInt32 (clrHex, 16);
		float color = (float)(num) / 255;

		
		return color;

	}

	public void Content(GameObject btn){

		string crdCode = btn.GetComponentInChildren<Text> ().text;

		if (crdCode[0] == 'C') {

			float r = returnToColor(crdCode.Substring(1,2));
			float g = returnToColor(crdCode.Substring(3,2));
			float b = returnToColor(crdCode.Substring(5,2));

			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				btn.GetComponent<Image>().color = new Color(r,g,b,1);
				btn.GetComponent<Image>().sprite = ctnImg;
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