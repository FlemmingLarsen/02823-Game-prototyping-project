using UnityEngine;
using System.Collections;

public class ObjectsMove : MonoBehaviour {

    public float speed = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.left * speed);
	}
}
