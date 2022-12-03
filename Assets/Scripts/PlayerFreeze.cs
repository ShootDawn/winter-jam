using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{
    public float freezeMeter = 0;
    public bool isFireplace = false;
    public float iceAlpha = 0;
    public SpriteRenderer ice;
    public int maxTime = 10;
    private FMOD.Studio.EventInstance windSFX;
    // Start is called before the first frame update
    void Start()
    {
        windSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/LevelSFX/WindHumming");
        windSFX.start();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isFireplace) { 
        if (freezeMeter < maxTime)
        {
                ice.color = new Color(22, 31, 41, iceAlpha);
                iceAlpha = freezeMeter / maxTime;
            freezeMeter += Time.deltaTime;
                windSFX.setParameterByName("Coldness", freezeMeter*10);

            } else
        {
            Debug.Log("you died!");
        }
        } else
        {
            if (freezeMeter > 0)
            {
                ice.color = new Color(22, 31, 41, iceAlpha);
                iceAlpha = freezeMeter / maxTime;
                freezeMeter -= Time.deltaTime*2;
                windSFX.setParameterByName("Coldness", freezeMeter*5);
            }
        }

    }
    void onDisable()
    {
        windSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        windSFX.release();
    }

}
