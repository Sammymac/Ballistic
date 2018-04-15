using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 mousePos;
    private bool hasFired = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse pressed");
            mousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            hasFired = true;
            print("Mouse released");
        }
    }

    private void FixedUpdate() {
        if (hasFired) {
            Vector2 movement = Input.mousePosition;

        }
    }
}
