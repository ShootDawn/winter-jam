using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMusic : MonoBehaviour
{
    public FMOD.Studio.EventInstance levelBGM;
    // Start is called before the first frame update
    void Start()
    {
        levelBGM = FMODUnity.RuntimeManager.CreateInstance("event:/BGM/BGM");
        levelBGM.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void onDisable()
    {
        levelBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        levelBGM.release();
    }
    void onDestroy()
    {
        levelBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        levelBGM.release();
    }
}
