using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorLibrary : MonoBehaviour {
	
	private List<string> Clrs = new List<string> ();

	private void startEasy(){
		Clrs.Add("FF0000");
	}

	private void startMedium(){
		Clrs.Add("FF0023");
	}

	private void startHard(){
		Clrs.Add("A9B140");
	}

	public List<string> gameSort(string dificulty){
		if (dificulty == "easy") {
			startEasy();
		} else if (dificulty == "medium") {
			startMedium();
		} else {
			startHard();
		}

		return Clrs;
	}
}
