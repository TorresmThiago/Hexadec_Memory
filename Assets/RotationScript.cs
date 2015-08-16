using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public void HelloWord (GameObject btn) {
		print (btn.GetComponentInChildren<Text>().text);
	}
}