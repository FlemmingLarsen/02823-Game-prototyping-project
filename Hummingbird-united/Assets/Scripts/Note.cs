using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public NoteSpawner noteSpawner;

	public Vector3 velocity = Vector3.zero;

	public bool isCounted = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition += velocity * Time.fixedDeltaTime;

		if (transform.localPosition.x < noteSpawner.destroyPoint.x) {
			noteSpawner.RecycleNote (this);
		}

		if (transform.localPosition.x < noteSpawner.bird.transform.position.x && isCounted == false){
			noteSpawner.healthBar.health -= 0.01f;
			isCounted = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		noteSpawner.RecycleNote(this);
	}
}
