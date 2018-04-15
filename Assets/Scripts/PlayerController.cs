﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Public variables
    public float speed;

    // Private variables
    private Rigidbody2D rb;
    private Vector2 mousePos;
    private bool hasFired = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            print("Mouse pressed");
            mousePos = Input.mousePosition;
        } else if (Input.GetMouseButtonUp(0)) {
            hasFired = true;
            print("Mouse released");
        }
    }

    private void FixedUpdate() {
        if (hasFired) {
            Vector2 movement = Input.mousePosition;
            Vector2 difference = movement - mousePos;

            print("Movement:"+movement);
            print("Difference:" + difference);
            rb.AddForce(difference * speed, ForceMode2D.Impulse);
            hasFired = false;
        }
    }
}
