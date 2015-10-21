using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorLibrary : MonoBehaviour {
	
	private List<string> tempClrs = new List<string> ();
	private List<string> Clrs = new List<string> ();

	private void startEasy(){
		//Cores primarias       //Combinaçao entre 2
		tempClrs.Add("FF0000"); tempClrs.Add("FFFF00"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000");
		tempClrs.Add("00FF00"); tempClrs.Add("FF00FF"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000");
		tempClrs.Add("0000FF"); tempClrs.Add("00FFFF"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000");

		for (int i = 0; i < 9; i++) {
			int index = Random.Range(0, tempClrs.Count);
			Clrs.Add(tempClrs[index]);
			tempClrs.Remove(tempClrs[index]);
		}
	}

	private void startMedium(){
		tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000");
		tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000");
		tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000"); tempClrs.Add("FF0000");
	
		for (int i = 0; i < 9; i++) {
			int index = Random.Range(0, tempClrs.Count);
			Clrs.Add(tempClrs[index]);
			tempClrs.Remove(tempClrs[index]);
		}
	}

	private void startHard(){
		for (int i = 0; i < 9; i++) {

			int r = Random.Range(0, 255);
			int g = Random.Range(0, 255);
			int b = Random.Range(0, 255);
			string rgb = r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
			Clrs.Add(rgb);

		}
	}

	public List<string> gameSort(string dificulty){
		if (dificulty == "easy") {
			startEasy();
		} else if (dificulty == "medium") {
			startMedium();
		} else {
			startHard();
		}

		return tempClrs;
	}
}
