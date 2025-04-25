using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject newMap;
    [SerializeField] private GameObject oldMap;
    [SerializeField] private GameObject currentMap;
    [SerializeField] private GameObject coinParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("start"))
        {
            if (oldMap != null)
            {
                Destroy(oldMap);
            }
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("mid"))
        {
            oldMap = currentMap;

            //spawning new map at the position of end point of old map.
            currentMap = Instantiate(newMap, oldMap.transform.GetChild(0).position, Quaternion.identity);

            collision.gameObject.SetActive(false);
        }

        //addition of coin score from scoring script.
        if (collision.gameObject.CompareTag("coin"))
        {
            Scoring.Instance.coinsCollected++;
            Destroy(collision.gameObject);
            //spawning coin destroy particles
            Instantiate(coinParticle, transform.position, Quaternion.identity);
        }

        //game over while the player touches the obstacle.
        if (collision.gameObject.CompareTag("obs"))
        {
            //Debug.Log("Game Over");
            Scoring.Instance.GameOver();
        }
    }
}