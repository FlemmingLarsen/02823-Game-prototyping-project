using UnityEngine;
using System.Collections;

public class rockSpawner : MonoBehaviour {

    public GameObject rock;
    public float maxPos = 3.5f;
    public float delayTimer = 1f;
    public float timer;

    // Use this for initialization
    void Start () {
        timer = delayTimer;
        
            
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector2 rockPos = new Vector2(transform.position.x, Random.Range(-3.5f, 3.5f));

            Instantiate(rock, rockPos, transform.rotation);
            timer = delayTimer;
        }
    }
}
