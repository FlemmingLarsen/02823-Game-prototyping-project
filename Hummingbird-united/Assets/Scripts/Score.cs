using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int score = 0;


	public void IncrementScore(){
		score += 10;
	}

	public void ResetScore(){
		score = 0;
	}


	// Use this for initialization
	void Start () {

		scoreText = GetComponent<Text> ();
		scoreText.text = "Score: " + score.ToString ();

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score.ToString ();

	}
}
