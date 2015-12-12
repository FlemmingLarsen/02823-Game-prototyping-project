using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	public GameControl gameControl;

	public Vector3 velocity = Vector3.zero;

	public bool isCounted = false;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition += velocity * Time.fixedDeltaTime;

		if (transform.localPosition.x < gameControl.destroyPoint.x) {
			gameControl.RecycleNote (this);
		}

		if (transform.localPosition.x < gameControl.bird.transform.position.x && isCounted == false){
			gameControl.healthBar.health -= 0.01f;
			isCounted = true;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		gameControl.RecycleNote(this);
		gameControl.score.IncrementScore();
	}
}
