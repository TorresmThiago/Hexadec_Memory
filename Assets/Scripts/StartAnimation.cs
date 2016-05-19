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
		print (cards.Length);
		foreach (GameObject card in cards) {
			Quaternion newRotation = Quaternion.AngleAxis (0, Vector3.down);
			card.transform.rotation = Quaternion.Slerp (card.transform.rotation, newRotation, 0.1f);
			if (card.transform.localEulerAngles.y <= 1) {
				card.transform.rotation = Quaternion.Euler (0, 0, 0);
				card.tag = "Cards"; 
			} 
		}
	}
	
	IEnumerator Lauch(){
		for (int i = 3; i > -3; i--) {
			for (int j = -1; j < 2; j++) {
				GameObject a = (GameObject)Instantiate (card, new Vector3(1.5f * j, 1.4f * i, transform.position.z), Quaternion.identity);
				a.transform.parent = gameObject.transform.parent;
				yield return new WaitForSeconds (.125f);
			}
		}
	}
}
