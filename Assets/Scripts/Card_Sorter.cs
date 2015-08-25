using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card_Sorter : MonoBehaviour {

	public GameObject Grid;
	public GameObject SrtGrid;
	private string type;
	private List<string> rdColors = new List<string>();

	void Awake () {
		Fill ();
	}

	void SortCards(){
		int index = 0;

		for (int i = 0; i < rdColors.Count; i++) {
			string temp = rdColors[i];
			int randomIndex = Random.Range(i, rdColors.Count);
			rdColors[i] = rdColors[randomIndex];
			rdColors[randomIndex] = temp;
		}
		
		for(int i = 0; i < rdColors.Count; i++){

			if(Grid.GetComponentInChildren<Button>().tag == "Untagged"){
				Grid.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = rdColors[index];
				Grid.GetComponentInChildren<Button>().transform.parent = SrtGrid.transform;
			}

			index++;

		}

	}

	void Fill(){

		for (int i = 0; i < 9; i++) {
			Color rdColor = new Color(Random.value, Random.value, Random.value, 1.0f);
			gameObject.GetComponent<Card_Content>().GetColor(rdColor);

			int r = (int)Mathf.Floor(rdColor.r * 255);
			int g = (int)Mathf.Floor(rdColor.g * 255);
			int b = (int)Mathf.Floor(rdColor.b * 255);
			string toShow = r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
			
			string code = "#" + toShow;
			string color = "C" + toShow;

			rdColors.Add(code);
			rdColors.Add(color);
		}

		SortCards ();
	}

}
