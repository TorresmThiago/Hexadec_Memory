using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ColorLibrary : MonoBehaviour {
	
	private List<string> tempClrs = new List<string> ();
	private List<string> Clrs = new List<string> ();

	private void startEasy(){
		
		tempClrs.Add("FF0000"); tempClrs.Add("FFFF00"); tempClrs.Add("33CCCC"); tempClrs.Add("3366FF"); tempClrs.Add("CC6600"); tempClrs.Add("663300");
		tempClrs.Add("00FF00"); tempClrs.Add("FF00FF"); tempClrs.Add("33CC33"); tempClrs.Add("FF6600"); tempClrs.Add("00CC00"); tempClrs.Add("CCCCCC");
		tempClrs.Add("0000FF"); tempClrs.Add("00FFFF"); tempClrs.Add("FF5050"); tempClrs.Add("66FF33"); tempClrs.Add("660066"); tempClrs.Add("66FFCC");

		for (int i = 0; i < 9; i++) {
			int index = Random.Range(0, tempClrs.Count);
			Clrs.Add(tempClrs[index]);
			tempClrs.Remove(tempClrs[index]);
		}
	}

	private void startMedium(){
		
		tempClrs.Add("009966"); tempClrs.Add("8B0000"); tempClrs.Add("B8FF00"); tempClrs.Add("C0000F"); tempClrs.Add("232323"); tempClrs.Add("808000");
		tempClrs.Add("FFC0CB"); tempClrs.Add("00A200"); tempClrs.Add("FFD700"); tempClrs.Add("00FF30"); tempClrs.Add("FF7F50"); tempClrs.Add("20B2AA");
		tempClrs.Add("DDA0DD"); tempClrs.Add("00004C"); tempClrs.Add("FF0045"); tempClrs.Add("00AAFF"); tempClrs.Add("BDB72D"); tempClrs.Add("E1D4C2");
	
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

	public List<string> gameSort (string dificulty){
		if (dificulty == "easy") {
			startEasy();
		} else if (dificulty == "medium") {
			startMedium();
		} else {
			startHard();
		}

		PlayerPrefs.SetFloat ("Time", Time.time);
		print (Time.time);
		return Clrs;
	}
}
