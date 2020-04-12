using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector2 mousePos;
    private Collider2D col;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = Input.mousePosition;

            var mouseWorldPos3D = cam.ScreenToWorldPoint(position);
            var mouseWorldPos = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
            print(col.bounds);
            print(mouseWorldPos);
            bool contains = col.bounds.Contains(mouseWorldPos);
            print(contains);
        }
    }
}
