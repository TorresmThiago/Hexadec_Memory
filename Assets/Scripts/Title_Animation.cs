using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Title_Animation : MonoBehaviour {
	
	private bool Up = true;
	private bool Down = false;
	private float velocity = 0.023f;
	public GameObject HexaText;
	public GameObject MemoText;
	public Camera MainCamera;
	private Color bgColor;

	void Start(){
		StartCoroutine (IsMoving ());
		StartCoroutine (ColorShifter ());
	}

	IEnumerator IsMoving(){
		if (Up && !Down) {
			HexaText.transform.position = new Vector3 (HexaText.transform.position.x, HexaText.transform.position.y + velocity, 0.0f);
			MemoText.transform.position = new Vector3 (MemoText.transform.position.x, MemoText.transform.position.y + velocity, 0.0f);
		}
		if (Down && !Up) {
			HexaText.transform.position = new Vector3 (HexaText.transform.position.x, HexaText.transform.position.y + (-velocity), 0.0f);
			MemoText.transform.position = new Vector3 (MemoText.transform.position.x, MemoText.transform.position.y + (-velocity), 0.0f);
		}

		yield return new WaitForSeconds (0.023f);
		StartCoroutine(IsMoving ());
	}

	void Update(){
		if (HexaText.transform.position.y >= 48/10) {
			Down = true;
			Up = false;
		} else if(HexaText.transform.position.y <= 39/10){
			Up = true;
			Down = false;
		}
	}

	IEnumerator ColorShifter(){
		while (true){ 
			bgColor = new Color(Random.value, Random.value, Random.value, 0.5f);

			float time = 0.0f;
			Color currentColor = MainCamera.backgroundColor;
			
			while( time < 1.0f ){
				MainCamera.backgroundColor = Color.Lerp(currentColor, bgColor, time );
				yield return new WaitForSeconds (0.023f);
				time += Time.deltaTime;
			}
		}
	}
}
