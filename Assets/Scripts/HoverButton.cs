using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    private Button spriteR;
    public Sprite buttonOff;
    public Sprite buttonOn;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    public void OnPointerEnter()
    {
        spriteR.image.sprite = buttonOn;
    }
    public void OnPointerExit()
    {
        spriteR.image.sprite = buttonOff;
    }
    private void OnDisable()
    {
        spriteR.image.sprite = buttonOff;
    }
}
