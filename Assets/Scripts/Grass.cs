using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public PlayerMovement player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.footstepsSFX.setParameterByName("FloorType", 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.footstepsSFX.setParameterByName("FloorType", 0);
    }
}
