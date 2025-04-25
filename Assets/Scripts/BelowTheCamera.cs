using UnityEngine;

public class BelowTheCamera : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //player collision.
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("game Over");
            Scoring.Instance.GameOver();
        }

        //obstacle collision.
        if (collision.gameObject.CompareTag("obs"))
        {
            Destroy(collision.gameObject);
        }

        //obstacle coin.
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
