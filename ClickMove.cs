using UnityEngine;
using FYFY;

public class ClickMove : FSystem {
	private Family _MoveByClickGO = FamilyManager.getFamily(new AllOfComponents(typeof(vitesse),typeof(clickTarget),typeof(selected)));
	Vector3 targetPosition;
		
	protected override void onProcess(int familiesUpdateCount){
		foreach (GameObject go in _MoveByClickGO) {

			vitesse v = go.GetComponent<vitesse> ();
			Transform tr = go.GetComponent<Transform> ();
				if(Input.GetMouseButtonDown(0)) {
					/*test 
					movement += Vector3.left; 
					tr.position += movement * v.speed * Time.deltaTime;
					 fin test */
					Plane playerPlane = new Plane (Vector3.up, tr.position);
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					float hitdist = 0.0f;
					if (playerPlane.Raycast(ray, out hitdist)) {
						Vector3 targetPoint = ray.GetPoint (hitdist);
						targetPosition = ray.GetPoint(hitdist);
						Quaternion targetRotation = Quaternion.LookRotation (targetPoint - tr.position);
						tr.rotation = targetRotation;
						}
				}

				tr.position = Vector3.MoveTowards (tr.position, targetPosition, v.speed*Time.deltaTime); 

			}
		
	}

	// Use this to update member variables when system pause. 
	// Advice: avoid to update your families inside this function.
	protected override void onPause(int currentFrame) {
		/*foreach (GameObject go in _MoveByClickGO) {
			Transform tr = go.GetComponent<Transform> ();
			targetPosition = go.transform.position;
		}*/
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}


}