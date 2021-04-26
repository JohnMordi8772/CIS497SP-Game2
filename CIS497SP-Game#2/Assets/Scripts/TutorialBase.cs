using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBase : TutorialTemplate
{
    bool pressD = false, pressA = false, pressW = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            pressA = true;
        if (Input.GetKeyDown(KeyCode.D))
            pressD = true;
        if (Input.GetKeyDown(KeyCode.W))
            pressW = true;
    }

    public override IEnumerator TutorialFunctions()
    {
        tutorialText.text = "This is your first intro to the games mechanics. You'll have new things to learn\n as you progress through the game, but we will go over everything you need to know now.\n(Left-Click to continue)";

        while(!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "You have just seen that left-clicking also makes your character attack, \nyou can use that to fight enemies you'll see in the game. You also have a ranged attack that you can use too.\nRight-click to try it out.";

        while (!Input.GetMouseButtonDown(1))
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "You do have a 3 second cooldown on the ranged attack,\n which can be seen in the bottom left.(Left-click to continue)";

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "Now, in order to move you will use A and D\nto go left and right respectively. Try it now.";
        pressA = false;
        pressD = false;

        while(!pressA || !pressD)
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "You can also double jump with W. Try it now.";
        pressW = false;

        while (!pressW)
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "You will need to use these mechanics to fight enemies and reach the end of the level.\nThe end of the level will always be found by going to the right.(Left-click to continue)";

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "All enemies take 2 hits from either of your attacks to kill them. You can take 3 hits from enemies\nas seen from your health in the top-left.(Left-click to continue)";

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "You have 3 lives total, so if your health drops to 0,\nyou'll go to your last checkpoint with 2 lives left.(Left-click to continue)";

        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        yield return null;

        tutorialText.text = "If you ever want to pause, go back to the main menu, or restart, just click P. Click P again to unpause.";

        while (!Input.GetKeyDown(KeyCode.P))
        {
            yield return null;
        }
        yield return null;

        finished = true;
        
    }
}
