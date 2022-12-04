using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public InGameMusic music;
    public int zone;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            music.levelBGM.setParameterByName("Zone", zone);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        music.levelBGM.setParameterByName("Zone", 1);
    }
}
