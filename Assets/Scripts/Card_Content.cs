using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card_Content : MonoBehaviour {

	public void Content(GameObject btn){

		string crdCode = btn.GetComponentInChildren<Text> ().text;

		if (crdCode[2] == 'l') {
		
			//btn.backgroundColor = Color.Lerp(currentColor, bgColor, time );

		} else if (crdCode[2] == 'd') {
		
			//btn.GetComponentInChildren<Text>().GetComponent<Text>().enabled = true;

		}
	}
}
