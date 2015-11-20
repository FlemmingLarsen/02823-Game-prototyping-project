using UnityEngine;
using System.Collections;

public class BirdControl : MonoBehaviour {

	private Rigidbody2D rb;
	public float verticalvel;

	void Awake (){
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)){
			rb.velocity = new Vector2(0, verticalvel);
			            }
			
		if (Input.GetKeyDown(KeyCode.DownArrow)){
				rb.velocity = new Vector2(0,-verticalvel);
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.DownArrow)) {
			rb.velocity = (new Vector2 (0, 0));
		}


	}


}
