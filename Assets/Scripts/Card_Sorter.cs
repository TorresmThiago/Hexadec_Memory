using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card_Sorter : MonoBehaviour {

	public GameObject Grid;
	private string type;
	private Color[] rdColors = new Color[9];

	void Awake () {
		Fill ();
	}

	void Fill(){
		/*foreach(GameObject row in Grid){
			foreach(GameObject txt in row) {
				foreach(GameObject txt in btn) {
					
				}
			}
		}*/
		for (int i = 0; i < rdColors.Length; i++) {
			Color rdColor = new Color(Random.value, Random.value, Random.value, 1.0f);
			rdColors[i] = rdColor;
		}
	}

}
