using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    int iScene;
    public void loadScene()
    {
        SceneManager.LoadScene(iScene);
    }
}
