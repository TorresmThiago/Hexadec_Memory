﻿using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	public void LoadScene(){

		switch (gameObject.tag) {
		
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
