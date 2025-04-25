using UnityEngine;

public class GroundSpawnPosition : MonoBehaviour
{
    [Header("X Position Range")]
    [SerializeField] private float leftXDir;
    [SerializeField] private float rightXDir;

    private void Start()
    {
        int xValue = (int)Random.Range(leftXDir, rightXDir);

        transform.position = new Vector2(xValue, transform.position.y);
    }

    //destroying if the obstacle or coins are spawned at the position of ground (Tile).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("obs"))
        {
            //Debug.Log("destroyed");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}