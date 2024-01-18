using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public string[] dialog;
    private int index;
    public GameObject continueButton;
    public float wordSpeed;
    public bool playerIsClose;
    void Update()
    {
        //Debug.Log("HEJ");
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogText.text == dialog[index])
        {
            continueButton.SetActive(true);
        }
    }
    public void zeroText()
    {
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);

    }
    IEnumerator Typing()
    {
        foreach (char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);

        }
    }
    public void NextLine()
    {
        continueButton.SetActive(false);
        if (index < dialog.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("halo");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player triggerd");
            playerIsClose = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
