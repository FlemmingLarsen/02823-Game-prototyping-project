﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))] // Require GUIText component so we can display a text
public class NoteFinder : MonoBehaviour
{
    public GameObject audioInputObject;
    public float threshold = 1.0f;
    MicrophoneInput micIn;
    // Use this for initialization
    void Start()
    {
        if (audioInputObject == null)
            audioInputObject = GameObject.Find("MicMonitor");
        micIn = (MicrophoneInput)audioInputObject.GetComponent("MicrophoneInput");
    }

    // Update is called once per frame
    void Update()
    {
        int f = (int)micIn.loudness; // Get the frequency from our MicrophoneInput script
        this.GetComponent<GUIText>().text = "Note played" + f;
        /*
        if (f >= 261 && f <= 262) // Compare the frequency to known value, take possible rounding error in to account
        {
            this.GetComponent<GUIText>().text = "Middle-C played!";
        }
        else
        {
            this.GetComponent<GUIText>().text = "Play another note...";
        }
         * */
    }
}