using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{

    public GameControl gameControl;

    public Vector3 velocity = Vector3.zero;

    public bool isCounted = false;
	
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition += velocity * Time.fixedDeltaTime;

        if (transform.localPosition.x < gameControl.destroyPoint.x)
        {
            gameControl.RecycleNote(this);
        }

        if (transform.localPosition.x < gameControl.bird.transform.position.x && isCounted == false)
        {
            gameControl.healthBar.health -= gameControl.healthDecrement;
            isCounted = true;
            //Osc send
            float noteloss= 1.0f;
            OSCHandler.Instance.SendMessageToClient("SuperCollider", "/notedestroy", noteloss);
        }
    }

    void Update()
    {
        if (gameControl.gameOver)
        {
            gameControl.RecycleNote(this);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        gameControl.RecycleNote(this);
        gameControl.score.IncrementScore();
        //Osc send
        float notePickup = 1.0f;
        OSCHandler.Instance.SendMessageToClient("SuperCollider", "/note", notePickup);
    }
}
