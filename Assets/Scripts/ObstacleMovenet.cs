using UnityEngine;

public class ObstacleMovenet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        //rotating obstacle.
        transform.Rotate(speed * Time.deltaTime * Vector3.up);
    }
}
