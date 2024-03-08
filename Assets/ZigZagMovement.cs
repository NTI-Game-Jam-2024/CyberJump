using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    public float speed = 10f; // Adjust speed as needed
    public bool Zig = true;
    public float updownSpeed = 10f; // Adjust updown speed as needed


    public Camera mainPlayerCam;
    public Camera geoCamera;
    public GameObject Player;
    public GameObject geometrydash;
    public GameObject triggerGeometryDash;

    public WinnerScript win; 

    public PlayerMovement player;

    // Reference to the Rigidbody2D component
    Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 20f)
        {
            
            Debug.Log("victory");
            triggerGeometryDash.SetActive(false);
            geoCamera.enabled = false;
            mainPlayerCam.enabled = true;
            geoCamera.depth = -2;
            geometrydash.SetActive(false);
            GetComponent<NumberMemory>().enabled = false;
            //player.Active = true;
            gameObject.SetActive(false);

            player.Active = true;
        } 

        // Move the GameObject forward in its local space
        transform.position += transform.up * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Zig)
            {

                rb.velocity = Vector2.zero;
                // Apply constant force for right and up movement
                rb.AddForce(-transform.right * updownSpeed, ForceMode2D.Impulse);
                rb.AddForce(Vector2.up * updownSpeed, ForceMode2D.Impulse);
            }
            else
            {
                rb.velocity = Vector2.zero;
                // Apply constant force for left and up movement
                rb.AddForce(transform.right *updownSpeed, ForceMode2D.Impulse);
                rb.AddForce(Vector2.down * updownSpeed, ForceMode2D.Impulse);
            }
            Zig = !Zig; // Toggle Zig
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector3(-37.8f, -45.6f, transform.position.z);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
    }

}
