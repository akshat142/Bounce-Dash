using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public static Scoring Instance;

    public TMP_Text scoreText;
    public TMP_Text coinText;
    public TMP_Text finalScoreText;
    public GameObject gameOverPanal;
    public float timeMultiplier = 10f;
    public int coinValue = 100;
    public int coinsCollected = 0;

    private float timeSurvived = 0f;
    private int finalScore = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameOverPanal.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeSurvived += Time.deltaTime;
            UpdateScoreDisplay();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        finalScore = CalculateScore();

        Time.timeScale = 0;
        //Debug.Log("Game Over! Final Score: " + finalScore);

        //Show final score on UI
        gameOverPanal.SetActive(true);

        finalScoreText.text = "Final Score : " + finalScore;
        coinText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    //calculating final score.
    int CalculateScore()
    {
        return (int)(timeSurvived * timeMultiplier) + (coinsCollected * coinValue);
    }


    //updating score and shows in UI.
    void UpdateScoreDisplay()
    {
        int currentScore = (int)(timeSurvived * timeMultiplier) + (coinsCollected * coinValue);
        scoreText.text = "Score: " + currentScore;
        coinText.text = "Coin : " + coinsCollected;
    }

    public void RestartButton()
    {
        //restarting the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
