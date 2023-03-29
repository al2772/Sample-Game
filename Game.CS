public class CharacterController : MonoBehaviour {

    // The speed at which the character moves
    public float moveSpeed = 5f;

    // The force with which the character jumps
    public float jumpForce = 10f;

    // The number of jumps the character has remaining
    private int jumpsLeft = 2;

    // The Rigidbody2D component attached to the character
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        // Move the character left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        // Jump if the player presses the spacebar
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (jumpsLeft > 0) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpsLeft--;
            }
        }
    }

    // Reset the jumpsLeft variable when the character lands on the ground
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            jumpsLeft = 2;
        }
    }
}
