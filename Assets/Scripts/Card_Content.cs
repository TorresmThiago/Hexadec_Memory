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
		Color tempClr = new Color(1,1,1,1); 

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
				btn.GetComponent<Image>().color = tempClr;
			}

		} else if (crdCode[2] == 'd') {
		
			if((int)btn.transform.localEulerAngles.y >= 90){
				//Mostrar
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = true;

				for(int i = 0; i < Clrs.Count; i++){
					if(Clrs[i].ToString() == crdCode.Substring(3)){
						int r = (int)Mathf.Floor(Clrs[i].r * 255);
						int g = (int)Mathf.Floor(Clrs[i].g * 255);
						int b = (int)Mathf.Floor(Clrs[i].b * 255);
						string toShow = "#" + r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
						print(toShow);
					}	
				}
			}

			if((int)btn.transform.localEulerAngles.y >= 270){
				//Nao Mostrar
				btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = false;
			}

		}
	}
}