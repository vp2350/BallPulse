using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void loadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
    }
}
