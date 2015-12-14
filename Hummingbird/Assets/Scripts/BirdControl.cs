using UnityEngine;
using System.Collections;

public class BirdControl : MonoBehaviour {

	private Rigidbody2D bird;
	public float verticalvel;

	void Awake (){
		bird = GetComponent<Rigidbody2D> ();
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			bird.velocity = new Vector2(0, verticalvel);
		}
			
		if (Input.GetKeyDown(KeyCode.DownArrow)){
				 bird.velocity = new Vector2(0,-verticalvel);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			bird.velocity = (new Vector2 (0, 0));
		}


	}


}
