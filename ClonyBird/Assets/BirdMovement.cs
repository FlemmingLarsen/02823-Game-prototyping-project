using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
    public GameObject audioInputObject;
    public float threshold = 1.0f;
    MicrophoneInput micIn;

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;
    public Vector3 oldPos;
    public Vector3 posDifference;

    public float ypos = 1f;

    bool didFlap = false;

	// Use this for initialization
	void Start () {
        if (audioInputObject == null)
            audioInputObject = GameObject.Find("MicMonitor");
        micIn = (MicrophoneInput)audioInputObject.GetComponent("MicrophoneInput");
	}

    void Update()
    {
        int f = (int)micIn.frequency; // Get the frequency from our MicrophoneInput script
        ypos = f / 60f + 0.5f;
        float l = (float)micIn.loudness;
        float lt = (float)micIn.loudnessThreshold;
        if (l > lt && f > 20)
        {
            oldPos = transform.position;
            transform.position = new Vector3(0f, ypos, 0f);
            float angle = 0;
            posDifference = oldPos - transform.position;
            transform.rotation = Quaternion.Euler(0, 0, -posDifference.y * 50);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        /*int f = (int)micIn.frequency; // Get the frequency from our MicrophoneInput script
        velocity.x = forwardSpeed;
        velocity += gravity * Time.deltaTime;

        if (didFlap == true)
        {
            didFlap = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            velocity += flapVelocity;
        }

        

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;
        float angle = 0;
        if(velocity.y < 0) {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);*/


	}
}
