
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
