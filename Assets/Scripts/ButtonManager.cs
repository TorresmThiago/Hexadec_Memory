using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	public void LoadScene(){
		if (gameObject.tag == "Play") {
			Application.LoadLevel (1);
		} else if (gameObject.tag == "Credits") {
			Application.LoadLevel (2);
		} else if (gameObject.tag == "Menu") {
			Application.LoadLevel (0);
		}
	}
}
