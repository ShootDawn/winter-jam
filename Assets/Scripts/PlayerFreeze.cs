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
    // Start is called before the first frame update
    void Start()
    {
        
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
                freezeMeter -= Time.deltaTime;
            }
        }

    }

}
