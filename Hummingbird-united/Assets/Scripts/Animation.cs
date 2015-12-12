﻿using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {
    bool IsGhost = false;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("IsGhost", true);
        }
	}
}
