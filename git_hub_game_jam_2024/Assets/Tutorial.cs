using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Tutorial : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    void Update()
    {
        if (playerIsClose)
        {
            Debug.Log("close");
            if (dialoguePanel.activeInHierarchy)
            {
                Debug.Log("text");
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                
            }
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    public void NextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = ""; 
            StartCoroutine(Typing());

        }
        else
        {
            zeroText();
        }
    }
  
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("triggerclose");
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("triggernotclose");
            playerIsClose = false;
            zeroText();
     
        }
    }

}
