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

    bool didFlap = false;

	// Use this for initialization
	void Start () {
        if (audioInputObject == null)
            audioInputObject = GameObject.Find("MicMonitor");
        micIn = (MicrophoneInput)audioInputObject.GetComponent("MicrophoneInput");
	}

    void Update()
    {
        int f = (int)micIn.loudness; // Get the frequency from our MicrophoneInput script

        if (Input.GetKeyDown("space"))
        {
            didFlap = true;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        int f = (int)micIn.frequency; // Get the frequency from our MicrophoneInput script
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

        transform.rotation = Quaternion.Euler(0, 0, angle);
	}
}
