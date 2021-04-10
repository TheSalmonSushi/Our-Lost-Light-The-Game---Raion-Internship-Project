using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void retry()
    {
        SceneManager.LoadScene(2);
    }
}
