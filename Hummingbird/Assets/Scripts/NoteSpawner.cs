using UnityEngine;
using System.Collections.Generic;


public class NoteSpawner : MonoBehaviour {

	public Note prefab;
	public GameObject[] notes;
	public float delay = 8.0f;
	public static int noteCluster = 5;
	public bool isActive = true;
	private float spawnOffset = 1.0f;

	public Vector3 spawnPoint;
	public Vector3 destroyPoint;

	public Vector3 screenSize;
	public float offset = 0f;

	private Stack<Note> objectPool = new Stack<Note>();

	private Note CreateNote(){
		if (objectPool.Count == 0) {

			Note note = Instantiate (prefab);
			note.noteSpawner = this;
			return note;
		}

		return objectPool.Pop();
	}

	public void RecycleNote(Note note){
		objectPool.Push(note);
	}
	
	// Use this for initialization
	void Start () {

		Camera camera = FindObjectOfType<Camera>();
		screenSize = camera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,camera.nearClipPlane));

		spawnPoint = new Vector3(screenSize.x, 0, 0);

		destroyPoint = new Vector3(-screenSize.x, 0, 0);

		StartCoroutine (NoteGenerator ());
	
	}

	void Update (){
	}

	System.Collections.IEnumerator NoteGenerator() {
		while (true) {

			yield return new WaitForSeconds (delay);

			Vector3 notePos = spawnPoint;

			if (isActive) {

				for (int n = 0; n < noteCluster; n++) {

					yield return new WaitForSeconds (delay / 2);

					Note note = CreateNote();
					note.transform.position = notePos;
					notePos.y += spawnOffset;

				}
			}
		}
	}
}
