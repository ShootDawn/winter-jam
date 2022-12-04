using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public PlayerFreeze playerStatus;

    private FMOD.Studio.EventInstance fireplaceSFX;
    // Start is called before the first frame update
    private void Start()
    {
        fireplaceSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/LevelSFX/FirePlace");
        fireplaceSFX.start();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(fireplaceSFX, gameObject.transform);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            playerStatus.isFireplace = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStatus.isFireplace = false;
        }
    }
    private void OnDisable()
    {
        fireplaceSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        fireplaceSFX.release();
    }
}
