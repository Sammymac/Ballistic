using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Public variables
    public float speed;
    public GameObject cursorTemplate;
    public Camera cam;

    // Private variables
    private Rigidbody2D rb;
    private Vector2 mousePos;
    private bool hasFired = false;
    private bool aiming = false;
    private GameObject cursor;

    // Use this for initialization
    void Start() {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (rb.IsSleeping()) { 
            if (Input.GetMouseButtonDown(0)) {
                mousePos = Input.mousePosition;
                aiming = true;
            } else if (Input.GetMouseButtonUp(0)) {
                hasFired = true;
            }
        }
    }

    private void FixedUpdate() {
        if (hasFired) {
            Vector2 movement = Input.mousePosition;
            Vector2 difference = movement - new Vector2(transform.position.x, transform.position.y);

            print("Movement:" + movement);
            print("Difference:" + difference);
            rb.AddForce(difference * speed, ForceMode2D.Impulse);
            hasFired = false;
            aiming = false;
            Destroy(cursor);
        } else {
            if (aiming && cursor == null) {
                Vector2 currentPos = new Vector3(transform.position.x, transform.position.y);
                Vector2 mousePosTemp = cam.ScreenToWorldPoint(mousePos);
                Vector2 halfwayPoint = mousePosTemp + ((currentPos - mousePosTemp) /2);
                cursor = Instantiate(cursorTemplate, halfwayPoint, Quaternion.identity);
                print("Created cursor at " + halfwayPoint);
                print("CurrentPos: " + currentPos);
                print("mousePos: " + mousePos);
            }
        }
    }
        
}
