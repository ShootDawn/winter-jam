using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryHouseActive : MonoBehaviour
{
    private FMOD.Studio.EventInstance houseSFX;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            houseSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/LevelSFX/PeopleTalkingInHouses");
            houseSFX.start();
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(houseSFX, gameObject.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            houseSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            houseSFX.release();
        }
    }
    private void OnDisable()
    {
        houseSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        houseSFX.release();
    }
}
