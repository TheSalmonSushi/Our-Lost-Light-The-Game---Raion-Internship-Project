using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retrylv2 : MonoBehaviour
{
    public void Retry2()
    {
        SceneManager.LoadScene(4);
    }

    public void Retry3()
    {
        SceneManager.LoadScene(6);
    }
}
