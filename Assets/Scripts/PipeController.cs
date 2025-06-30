using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed = 5f; // Increased speed for smoother movement
    public float deadZone = -45f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Use a more consistent movement calculation
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
