using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Transform innerSpriteBar;

	//Health decrements every time a note is missed. 
	public float health = 1;

	public float offset;

	private float barSize = 7.0f;

	
	// Use this for initialization
	void Start () {
		innerSpriteBar = this.gameObject.transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {

		innerSpriteBar.localScale = new Vector3(health,1,1);

		offset = ((health - 1.0f) / 2.0f) * barSize;

		innerSpriteBar.transform.localPosition = new Vector3 (offset, 0, 0);


	}
}
