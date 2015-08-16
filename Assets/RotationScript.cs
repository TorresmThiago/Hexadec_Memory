using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotationScript : MonoBehaviour {

	/*public void HelloWord (GameObject btn) {
		print (btn.GetComponentInChildren<Text>().text);
	}*/

	IEnumerator FixAngle(GameObject toFix){
		switch ((int)toFix.transform.localEulerAngles.y) {
			case 179:
				toFix.transform.rotation = Quaternion.Euler (0, 180, 0);
				break;
		}

		yield return new WaitForSeconds (0.23f);
	}

	public void Move(GameObject btn){
		while (btn.transform.localEulerAngles.y <= 180) {
			Quaternion newRotation = Quaternion.AngleAxis (180, Vector3.down);
			btn.transform.rotation = Quaternion.Slerp (btn.transform.rotation, newRotation, 0.1f);
			StartCoroutine(FixAngle(btn));
		}
	}
}