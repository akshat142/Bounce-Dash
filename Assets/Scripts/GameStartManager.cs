using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    //start button behaviour.
    public void StartButton(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
