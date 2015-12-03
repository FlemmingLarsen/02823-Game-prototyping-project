using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour {

	public GameObject[] prefabs;
	public float delay = 8.0f;
	public bool isActive = true;
	public int noteCluster = 5;
	public float offset = 0.01f;

	public Vector3 spawnPoint;
	
	// Use this for initialization
	void Start () {

		spawnPoint = transform.position;
		StartCoroutine (NoteGenerator ());
	
	}

	IEnumerator NoteGenerator() {

		yield return new WaitForSeconds (delay);

		float notes = noteCluster;

		if (isActive) {

			while (notes >= 0) {

				yield return new WaitForSeconds (delay/2);

				var newTransform = transform;

				Instantiate(prefabs[0], transform.position, Quaternion.identity);
				transform.position =  new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
				notes--;

			}
			transform.position = spawnPoint;
		}


		StartCoroutine (NoteGenerator ());
	}
}
