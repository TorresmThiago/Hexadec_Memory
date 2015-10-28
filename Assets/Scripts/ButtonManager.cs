using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	//Just for the credits, my bad :C
	public GameObject fader;

	public IEnumerator menu(){
		yield return new WaitForSeconds (1.37f);
		gameObject.GetComponent<Button> ().interactable = true;
	}

	public void Start(){
		if (Application.loadedLevel == 0) {
			StartCoroutine(menu ());
		}
	}

	public void LoadScene(){

		switch (gameObject.tag) {

			case "Menu":
				Instantiate(fader);
				break;
		
			case "Play":
				Application.LoadLevel (1);
				break;

			case "Easy":
				Application.LoadLevel (2);
				PlayerPrefs.SetString ("dificulty", "easy");
				break;

			case "Medium":
				Application.LoadLevel (2);
				PlayerPrefs.SetString ("dificulty", "medium");
				break;

			case "Hard":
				Application.LoadLevel (2);
				PlayerPrefs.SetString ("dificulty", "You shall suffer.");
				break;
			
		
		}
	}
}
