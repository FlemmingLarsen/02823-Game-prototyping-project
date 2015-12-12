﻿using UnityEngine;
using System.Collections.Generic;


public class NoteSpawner : MonoBehaviour {

	public Note prefab;
	public GameObject[] notes;
	public float delay = 8.0f;
	public const int noteCluster = 5;
	public bool isActive = true;
	private float spawnOffset = 1.0f;

	public Vector3 spawnPoint;
	public Vector3 destroyPoint;

	public Vector3 screenSize;
	public float offset = 0f;

	public Transform bird;
	public HealthBar healthBar;

	private Stack<Note> objectPool = new Stack<Note>();

	// Defining the different note sequences.
	private static float[] noteseq1 = new float[noteCluster]{0.0f,1.0f,2.0f,3.0f,4.0f}; // Increasing
	private static float[] noteseq2 = new float[noteCluster]{0.0f,4.0f,0.0f,4.0f,0.0f}; // High and low, low start
	private static float[] noteseq3 = new float[noteCluster]{0.0f,1.0f,2.0f,1.0f,0.0f}; // Bridge  
	private static float[] noteseq4 = new float[noteCluster]{4.0f,0.0f,4.0f,0.0f,4.0f}; // High and low, high start
	private static float[] noteseq5 = new float[noteCluster]{4.0f,3.0f,2.0f,1.0f,0.0f}; // Decreasing

	private float[][] seqsList = new float[][]{noteseq1, noteseq2, noteseq3, noteseq4, noteseq5};

	private Note CreateNote(){
		if (objectPool.Count == 0) {

			Note note = Instantiate (prefab);
			note.noteSpawner = this;

			return note;
		}

		Note newNote = objectPool.Pop();
		newNote.gameObject.SetActive (true);
		return newNote;
	}

	public void RecycleNote(Note note){

		note.gameObject.SetActive (false);

		note.isCounted = false;
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

				int noteSeq = Random.Range(0, seqsList.Length);

				float yRange = (float) noteCluster * spawnOffset;

				// Make sure all notes are on screen. 
				if (noteSeq < 3){
					// Make sure low starting sequences stay below top of screen.
					notePos.y = Random.Range(-screenSize.y + spawnOffset , screenSize.y - yRange);
				
				}else{
					// Make sure high starting sequences stay above bottom of screen.
					notePos.y = Random.Range(-screenSize.y + yRange, screenSize.y - spawnOffset);
				}

				for (int n = 0; n < noteCluster; n++) {

					yield return new WaitForSeconds (delay / 2);

					Note note = CreateNote();
					note.transform.position = notePos;

					// Find y-position for next note, unless current is last.
					if (n < noteCluster - 1){
						notePos.y += spawnOffset * (seqsList[noteSeq][n+1] - seqsList[noteSeq][n]);
					}
				}
			}
		}
	}
}
