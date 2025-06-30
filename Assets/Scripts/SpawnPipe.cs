using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    public float spawnRate = 2;
    private float timer = 0;
    public float spawnHeight = 10;
    public float spawnOffsetX = 5f; // Distance off-screen to spawn pipes
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();
            timer = 0f;
        }
    }

    private void Spawn()
    {
        float lowerBound = transform.position.y - spawnHeight;
        float upperBound = transform.position.y + spawnHeight;
        // Spawn pipes off-screen to the right so they slide in smoothly
        Vector3 spawnPosition = new Vector3(transform.position.x + spawnOffsetX, Random.Range(lowerBound, upperBound), 0);
        Instantiate(pipePrefab, spawnPosition, transform.rotation);
    }
}
