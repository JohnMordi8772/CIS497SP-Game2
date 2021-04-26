/* (Ashton Lively) 
 * (DialogueManager) 
 * (Project 6) 
 * (Change and display dialogue) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogue;

    public GameObject charName;
    public Image image;

    public void ChangeDialogue(string next, float time)
    {
        dialogue.text = next;
        image.enabled = true;
        charName.SetActive(true);
        StartCoroutine(DisplayDialogue(time));
    }

    public IEnumerator DisplayDialogue(float time)
    {
        dialogue.color = new Color(dialogue.color.r, dialogue.color.g, dialogue.color.b, 0);
        // Fade in 
        while (dialogue.color.a <= 1)
        {
            dialogue.color = new Color(dialogue.color.r, dialogue.color.g, dialogue.color.b, dialogue.color.a + (Time.timeScale * .01f));
            yield return null;
        }

        yield return new WaitForSeconds(time);

        // Fade out
        while (dialogue.color.a >= 0)
        {
            dialogue.color = new Color(dialogue.color.r, dialogue.color.g, dialogue.color.b, dialogue.color.a - (Time.timeScale * .01f));
            yield return null;
        }

        image.enabled = false;
        charName.SetActive(false);
    }
}
