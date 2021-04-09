using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDontDuplicate : MonoBehaviour
{
    static SoundDontDuplicate instance = null;

    void Update()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
     
}
