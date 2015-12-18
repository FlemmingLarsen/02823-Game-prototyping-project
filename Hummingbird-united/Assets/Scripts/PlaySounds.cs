using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {

    public void flap ()
    {
        //Osc send
        float flapSound = 1.0f;
        OSCHandler.Instance.SendMessageToClient("SuperCollider", "/flap", flapSound);
    }
}
