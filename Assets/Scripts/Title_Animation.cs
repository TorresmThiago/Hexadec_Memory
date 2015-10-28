using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title_Animation : MonoBehaviour {

	public Camera MainCamera;
	public GameObject Wave;
	public float time;
	private Color bgColor;
	private bool onMenu;

	void Start(){
		StartCoroutine (ColorShifter ());
	}
	
	IEnumerator ColorShifter(){
		if (Application.loadedLevel == 0) {
			yield return new WaitForSeconds (time);
			Instantiate (Wave);
		}

		while (true){ 
			bgColor = new Color(Random.value, Random.value, Random.value, 0.5f);

			float time = 0.0f;
			Color currentColor = MainCamera.backgroundColor;
			
			while( time < 1.0f ){
				MainCamera.backgroundColor = Color.Lerp(currentColor, bgColor, time );
				yield return new WaitForSeconds (0.0123f);
				time += Time.deltaTime;
			}
		}
	}
}
