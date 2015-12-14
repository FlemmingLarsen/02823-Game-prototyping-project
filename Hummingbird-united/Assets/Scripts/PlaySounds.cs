using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

    public void Start()
    {
        //Init fly sound
        StartCoroutine(StartFlySound(0.5f));

    }
    IEnumerator StartFlySound(float time)
    {
        yield return new WaitForSeconds(time);

        float flySound = 1.0f;
        OSCHandler.Instance.SendMessageToClient("SuperCollider", "/fly", flySound);
    }
    public void flap ()
    {
        //Osc send
        float flapSound = 1.0f;
        OSCHandler.Instance.SendMessageToClient("SuperCollider", "/flap", flapSound);
    }
}
