/* (John Mordi) 
 * (TutorialTemplate) 
 * (Project 6) 
 * (This is what starts up the tutorial level of the game) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class TutorialTemplate : MonoBehaviour
{
    public Text tutorialText;
    public bool finished;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartTutorial());
        finished = false;
    }

    public IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(1);

        DisplayIntroText();
        yield return new WaitForSeconds(4);

        StartCoroutine(TutorialFunctions());

        while(!finished)
        {
            yield return null;
        }

        DisplayEndingText();
        
    }

    public void DisplayIntroText()
    {
        tutorialText.text = "Welcome to the tutorial, here you will learn some functions of the game.";
    }

    public abstract IEnumerator TutorialFunctions();

    public void DisplayEndingText()
    {
        tutorialText.text = "You have finished the tutorial, go to the pause menu and return to the main menu to continue the game.";
    }
}
