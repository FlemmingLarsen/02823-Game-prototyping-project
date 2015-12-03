using UnityEngine;
using System.Collections;

public class DestroyOffScreen : MonoBehaviour {

	public float offset = 16f;

	private bool isOffScreen;

	private float OffScreenX = 0;	

	private Rigidbody2D body2d;


	// Use this for initialization
	void Awake () {
	
		body2d = GetComponent < Rigidbody2D>();

	}

	void Start(){
		OffScreenX = Screen.width / 2 + offset;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
