using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPickup : MonoBehaviour
{
    public bool inRange;
    public bool isMap;
    public GameObject map;
    // Start is called before the first frame update
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.X))
        {
            if (!isMap)
            {
                map.SetActive(true);
                isMap = true;
            }
            else
            {
                map.SetActive(false);
                isMap = false;
            }
        }
    }

    // Update is called once per frame
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
            map.SetActive(false);
            inRange = false;

        }
    }
}
