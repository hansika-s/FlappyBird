using UnityEngine;
using UnityEngine.InputSystem;


public class BirdController : MonoBehaviour
{
    public LogicScript logic;
    public float flapStrength = 10f;
    public bool birdIsAlive = true;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            rb.linearVelocity = Vector2.up * flapStrength;
        }
        if ((transform.position.y < -20f || transform.position.y > 20f) && birdIsAlive)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        birdIsAlive = false;
    }
}
