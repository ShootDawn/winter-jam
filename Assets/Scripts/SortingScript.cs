using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingScript : MonoBehaviour
{
    private SpriteRenderer myRenderer;
    private Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myTransform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // myRenderer.sortingOrder = -(int)myTransform.position.y;
    }
}
