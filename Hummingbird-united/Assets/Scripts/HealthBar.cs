using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Transform innerSpriteBar;

	//Health decrements every time a note is missed. 
	public float health = 1;

	public float offset;

	private float barSize = 7.0f;
	public Vector3 screenSize;
	private float xOffset = 0.3f;
	private float yOffset = -0.1f;
	
	// Use this for initialization
	void Start () {
		
		//Make sure the health bar is in the upper left corner of the screen. 
		Camera camera = FindObjectOfType<Camera>();
		screenSize = camera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,camera.nearClipPlane));
		transform.position = new Vector3 (-screenSize.x + xOffset*barSize, screenSize.y + yOffset*barSize, 0);

		innerSpriteBar = this.gameObject.transform.GetChild (0);

	}
	
	// Update is called once per frame
	void Update () {

		innerSpriteBar.localScale = new Vector3(health,1,1);

		offset = ((health - 1.0f) / 2.0f) * barSize;

		if (health >= 0) { 
			innerSpriteBar.transform.localPosition = new Vector3 (offset, 0, 0);
		} else {
			innerSpriteBar.localScale = new Vector3 (0,1,1);
		}
	
	}
}
