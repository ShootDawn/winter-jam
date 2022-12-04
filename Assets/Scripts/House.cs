using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public int Keys;
    public int maxKeys;
    public bool inRange;
    public Transform player;
    private void Update()
    {
        if(inRange && Input.GetKeyDown(KeyCode.X) && (Keys >= maxKeys))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/levelSFX/HouseUnlock");
            Debug.Log("game over");
            player.transform.position = new Vector2(-56, 162);
        } else if (inRange && Input.GetKeyDown(KeyCode.X) && (Keys < maxKeys))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/levelSFX/HouseUnlockFail");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
