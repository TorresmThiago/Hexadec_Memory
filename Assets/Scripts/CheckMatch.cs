using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckMatch : MonoBehaviour {

	string returnHex(GameObject btn){
		//Lembrar: As cartas irao ter o nome com um index na frente: Col(or) ou Cod(e)  EX: Col92AF2B == Cod92AF2B
		string hex = btn.GetComponentInChildren<Text> ().text.Substring (0);
		return hex;
	}

	public bool check(GameObject btn_a, GameObject btn_b){
		string hex_a = returnHex (btn_a);
		string hex_b = returnHex (btn_b);

		if (hex_a == hex_b) {
			return true;
		}

		return false;
	}

}
