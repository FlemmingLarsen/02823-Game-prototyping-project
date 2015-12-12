using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{

    public GameControl gameControl;

    public Vector3 velocity = Vector3.zero;

    public bool isCounted = false;

    public float healthDecrement = 0.4f;

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
            gameControl.healthBar.health -= healthDecrement;
            isCounted = true;
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
    }
}
