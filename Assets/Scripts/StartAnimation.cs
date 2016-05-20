using UnityEngine;
using System.Collections;

public class StartAnimation : MonoBehaviour {

	public GameObject card;
	private GameObject[] cards;

	void Start () {
		StartCoroutine (Lauch ());
	}

	void Update () {
		rotate ();
	}

	void rotate(){
		cards = GameObject.FindGameObjectsWithTag ("StartCards");
		foreach (GameObject card in cards) {
			Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.down);
			card.transform.rotation = Quaternion.Slerp (card.transform.rotation, newRotation, 0.1f);
			if (card.transform.localEulerAngles.y <= 1) {
				card.transform.rotation = Quaternion.Euler (0, 0, 0);
				card.tag = "Cards"; 
			} 
		}
	}

	void setPosition(Vector3 position, GameObject obj){
		obj.GetComponent<RectTransform> ().position = position;
	}
	
	IEnumerator Lauch(){
		for (int i = 0; i < 6; i++) {
			for (int j = 0; j < 3; j++) {
				GameObject a = Instantiate (card);
				a.GetComponent<RectTransform> ().position = new Vector3 (-180 + (180 * j), 375 - (180 * i), 0);
				a.transform.SetParent (gameObject.transform.parent, false);
				yield return new WaitForSeconds (.1f);
			}
		}
	}
}
