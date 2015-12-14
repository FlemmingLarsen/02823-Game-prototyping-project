using UnityEngine;
using System.Collections;

public class RockCollide : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameObject gameControl = GameObject.Find("GameControl");
            gameControl.GetComponent<GameControl>().healthBar.health -= gameControl.GetComponent<GameControl>().healthDecrement * 2;

            //Osc send
            float hitObstacle = 1.0f;
            OSCHandler.Instance.SendMessageToClient("SuperCollider", "/obstacle", hitObstacle);

        }
        else if (collider.gameObject.tag == "destroyer")
        {
            Destroy(gameObject);
        }
    }
}
