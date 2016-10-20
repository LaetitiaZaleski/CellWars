using UnityEngine;
using FYFY;

public class RandomMove : FSystem {

	private Family _MoveRandomGO = FamilyManager.getFamily(new AllOfComponents(typeof(vitesse),typeof(randomTarget)));
	Vector3 targetPosition;
	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {

		foreach (GameObject go in _MoveRandomGO) {

			vitesse v = go.GetComponent<vitesse> ();
			Transform tr = go.GetComponent<Transform> ();

			targetPosition = new Vector3 (Random.Range (-4, 4), 0, Random.Range (-4, 4));

			tr.position = Vector3.MoveTowards (tr.position, targetPosition, v.speed * Time.deltaTime); 
		}

	}
}