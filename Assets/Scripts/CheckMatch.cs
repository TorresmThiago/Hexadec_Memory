using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckMatch : MonoBehaviour {
	string returnHex(GameObject btn){
		string hex = btn.GetComponentInChildren<Text> ().text.Substring (1);
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
