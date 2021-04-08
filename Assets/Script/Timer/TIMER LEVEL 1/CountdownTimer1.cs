using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer1 : MonoBehaviour
{
    public int iLevelToLoad;
    public string sLevelToLoad;
    public bool useIntegerToLoadLevel = false;


    float CurrentTime = 0f;
    float StartingTime = 30f;

    [SerializeField] Text countdownText ;



    
    void Start()
    {
        CurrentTime = StartingTime;
    }

    
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        countdownText.text = CurrentTime.ToString ("0");

        if (CurrentTime <= 0)
        {
            LoadScene();
        }
    
        void LoadScene()
        {
            if (useIntegerToLoadLevel)
            {
                SceneManager.LoadScene(iLevelToLoad);
            }

            else
            {
                SceneManager.LoadScene(sLevelToLoad);
            }
        }
    }
}