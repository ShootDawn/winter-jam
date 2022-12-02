using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public string[] linesBlurred;
    public float textSpeed = 0.05f;
    public GameObject dialogueBox;
    public bool inRange = false;
    public bool dialogue = false;
    public bool isBlurred = true;
    public bool hasGivenKey = false;
    public House House;

    private int index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.X))
        {
            if (dialogue == false)
            {
                textComponent.text = string.Empty;
                dialogueBox.SetActive(true);
                startDialogue();
                dialogue = true;
            } else {
                if (isBlurred && textComponent.text == linesBlurred[index])
                {
                    nextLineBlurred();
            }else if (!isBlurred &&  textComponent.text == lines[index]) {
                nextLine();
            }
            else
            {
                    
                    StopAllCoroutines();
                    if(isBlurred) { 
                    textComponent.text = linesBlurred[index];
                    } else
                    {
                    textComponent.text = lines[index];
                    }

                }
            }
        }

    }
    //start the dialogue
    public void startDialogue()
    {
        index = 0;
        if(isBlurred)
        {
        StartCoroutine(TypeLineBlurred());
        } else
        {
            if (!hasGivenKey)
            {
                House.Keys++;
                hasGivenKey = true;
            }
        StartCoroutine(TypeLine());
        }
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
            dialogueBox.SetActive(false);
            dialogue = false;
            
        }
    }

    void nextLineBlurred()
    {
        if (index < linesBlurred.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLineBlurred());
        }
        else
        {
            index = 0;
            dialogueBox.SetActive(false);
            dialogue = false;
        }
    }


    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    IEnumerator TypeLineBlurred()
    {
        foreach (char c in linesBlurred[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(0.01f);
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
            index = 0;
            StopAllCoroutines();
            dialogueBox.SetActive(false);
            inRange = false;
            dialogue = false;
            
        }
    }
}