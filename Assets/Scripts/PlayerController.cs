using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Public variables
    public int player;
    public float speed;
    public GameObject cursorTemplate;
    public GameController gameController;

    // Private variables
    private Camera cam;
    private Rigidbody2D rb;
    private Collider2D col;
    private Vector2 mousePos;
    private bool hasFired = false;
    private bool aiming = false;
    private GameObject cursor;

    // Use this for initialization
    void Start()
    {
//        Cursor.visible = false; // FIXME Uncomment this when testing finished
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            mousePos = Input.mousePosition;
            if (IsClickWithinPlayerRadius(mousePos)) {
                aiming = true;
            }
        }
        else if (Input.GetMouseButtonUp(0)) {
            if (aiming) {
                hasFired = true;
            }
        }
    }

    private void FixedUpdate() {
        Vector2 currentPlayerPosition = new Vector3(transform.position.x, transform.position.y);
        Vector2 currentMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (hasFired) {
            var difference = currentMousePosition - new Vector2(transform.position.x, transform.position.y);

            print("Fired");

            rb.AddForce(difference * speed, ForceMode2D.Impulse);
            hasFired = false;
            aiming = false;
            gameController.incrementCurrentScore(player);
            Destroy(cursor);
        }

        if (aiming) {
            if (cursor == null) {
                cursor = Instantiate(cursorTemplate, currentPlayerPosition, Quaternion.identity);
            }

            RotateCursorToMousePos();
            ScaleCursorToMousePos();
        }
    }

    private void ScaleCursorToMousePos() {
        Vector2 currentPlayerPosition = new Vector3(transform.position.x, transform.position.y);
        Vector2 currentMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        var distance = Vector3.Distance(currentPlayerPosition, currentMousePosition);
        cursor.transform.localScale = new Vector3(distance / 2.5F, 1, 0);
    }

    private void RotateCursorToMousePos() {
        var currentPlayerPosition = cam.WorldToScreenPoint(transform.position);
        var mousePosition = Input.mousePosition;
        mousePosition.x = mousePosition.x - currentPlayerPosition.x;
        mousePosition.y = mousePosition.y - currentPlayerPosition.y;
        var angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        cursor.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private bool IsClickWithinPlayerRadius(Vector2 position) {
        var mouseWorldPos3D = cam.ScreenToWorldPoint(position);
        var mouseWorldPos = new Vector2(mouseWorldPos3D.x, mouseWorldPos3D.y);
        print(mouseWorldPos);
        return col.bounds.Contains(mouseWorldPos);
    }

}
