/* (Ashton Lively) 
 * (DialogueHit) 
 * (Project 6) 
 * (Detect collision on dialogue triggers) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHit : MonoBehaviour
{
    private DialogueManager manager;

    [TextArea(1, 10)]
    public string dialogue;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Dialogue should be executing.");
            manager.ChangeDialogue(dialogue, time);
            Destroy(gameObject);
        }
    }
}
