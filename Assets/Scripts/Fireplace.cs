using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public PlayerFreeze playerStatus;

    private FMOD.Studio.EventInstance fireplaceSFX;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fireplaceSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/LevelSFX/FirePlace");
            fireplaceSFX.start();
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(fireplaceSFX, gameObject.transform);
            playerStatus.isFireplace = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fireplaceSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            fireplaceSFX.release();
            playerStatus.isFireplace = false;
        }
    }
}
