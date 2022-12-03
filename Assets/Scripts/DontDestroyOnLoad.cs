using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static bool created;
    // Start is called before the first frame update
    void Awake()
    {
        if (created)
        {
            Destroy(gameObject);
        }
        else 
        {         
            created = true;
            DontDestroyOnLoad(gameObject);
        }
    }
   public void playMenuClick()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Menu/Click");
    }

}
