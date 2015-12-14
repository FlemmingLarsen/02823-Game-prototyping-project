using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
    public GameObject audioInputObject;
    public float threshold = 1.0f;
    MicrophoneInput micIn;
    public Vector2 newYPos;
    bool IsGhost = false;
    Animator animator;

	// Use this for initialization
	void Start () {


        animator = GetComponent<Animator>();
        if (audioInputObject == null)
            audioInputObject = GameObject.Find("MicMonitor");
        micIn = (MicrophoneInput)audioInputObject.GetComponent("MicrophoneInput");
	}

    void Update()
    {
        int f = (int)micIn.frequency; // Get the frequency from our MicrophoneInput script
        float yCord = (f / 440f * 7f) - 7.8f;
        if (yCord > 5f) {
            newYPos = new Vector2(0, 5);
        }
        else if (yCord < -5f)
        {
            newYPos = new Vector2(0, -5);
        }
        else
        {
            newYPos = new Vector2(0, yCord);
        }
        float l = (float)micIn.loudness;
        float lt = (float)micIn.loudnessThreshold;
        if (l > lt && f > 20)
        {
            animator.SetBool("IsGhost", false);
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), newYPos, 3 * Time.deltaTime);
        }
        else if (l <= lt) 
        {
            animator.SetBool("IsGhost", true);
        }
    }
}
