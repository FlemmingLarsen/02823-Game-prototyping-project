using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public NoteSpawner noteSpawner; 

	public Vector3 velocity = Vector3.zero;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition += velocity * Time.fixedDeltaTime;

		if (transform.localPosition.x < noteSpawner.destroyPoint.x) {
			noteSpawner.RecycleNote (this);
		}
	}
}
