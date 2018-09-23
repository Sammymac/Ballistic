using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Public variables
    public float speed;
    public GameObject cursorTemplate;
    public Camera cam;

    // Private variables
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 mousePos;
    private bool hasFired = false;
    private bool aiming = false;
    private GameObject cursor;

    // Use this for initialization
    void Start()
    {
        //Cursor.visible = false; // FIXME Uncomment this when testing finished
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.IsSleeping()) {
            if (Input.GetMouseButtonDown(0)) {
                mousePos = Input.mousePosition;
                if (IsClickWithinPlayerRadius(mousePos)) {
                    //mousePos = Input.mousePosition;
                    //mousePos = cam.WorldToScreenPoint(col.bounds.center);

                    print("Position:" + transform.position);
                    print("Input.mousePosition:" + Input.mousePosition);
                    aiming = true;
                }
            } else if (Input.GetMouseButtonUp(0)) {
                if (aiming) {
                    hasFired = true;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 currentPlayerPosition = new Vector3(transform.position.x, transform.position.y);
        Vector2 currentMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (hasFired) {
            Vector2 difference = currentMousePosition - new Vector2(transform.position.x, transform.position.y);
            
            //difference = newMousePos - col.bounds.center;
            print("Fired");

            rb.AddForce(difference * speed, ForceMode2D.Impulse);
            hasFired = false;
            aiming = false;
            Destroy(cursor);
        }
        
        if (aiming) {
            if (cursor == null) {
                print("New cursor");
                cursor = Instantiate(cursorTemplate, currentPlayerPosition, Quaternion.identity);
                print("currentPlayerPosition:"+currentPlayerPosition);
                print("currentMousePosition:"+currentMousePosition);
            }
            
            // Aiming Code
            
            Vector3 object_pos = Camera.main.WorldToScreenPoint(currentPlayerPosition);
            Vector3 mouse_pos = Input.mousePosition;
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            cursor.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
//            cursor.transform.right = currentMousePosition - currentPlayerPosition;
//            cursor.transform.LookAt(currentMousePosition);

            // Scaling code
            Vector3 objectScale = cursor.transform.localScale;
            float distance = Vector3.Distance(currentPlayerPosition, currentMousePosition);
            float x = cursor.GetComponent<Collider2D>().bounds.size.x;

//            Vector3 newScale = new Vector3(distance/(x*2), distance/(x*2), 0);
//            cursor.transform.localScale = newScale;

//            print("Distance:" + distance);
//            print("x:" + x);
//            print("objectScale:" + objectScale);
//            print("newScale:" + newScale);
        }



    }
    

    private bool IsClickWithinPlayerRadius(Vector2 position) {
        Vector3 mouseWorldPos3D = Camera.main.ScreenToWorldPoint(position);
        Vector2 mouseWorldPos = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
        return col.bounds.Contains(mouseWorldPos);
    }


}
