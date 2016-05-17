using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	
	IEnumerator StartAudio(){
		yield return new WaitForSeconds (1.37f);
		gameObject.GetComponent<AudioSource>().Play ();
	}
	
	void Awake(){
		StartCoroutine (StartAudio());
	}
	
	void Start () {
		GameObject[] spawned = GameObject.FindGameObjectsWithTag("Audio");
		if(spawned.Length == 1)
			DontDestroyOnLoad (gameObject);	
	}
}
