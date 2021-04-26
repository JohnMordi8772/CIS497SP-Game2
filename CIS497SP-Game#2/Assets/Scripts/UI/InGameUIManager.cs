/* (John Mordi) 
 * (InGameUIManager) 
 * (Project 6) 
 * (As it says in title this manages the majority of the big UI stuff, like Lives) */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    private LifeVisualManager lives;

    private PointManager pointsManager;

    private int playerHealthMax = 3;
    private int playerLivesMax = 2;
    public Text livesText;
    private int currPlayerHealth;
    private int currPlayerLives;

    public PlayerController player;

    public Text lossText;

    [Tooltip("Text display number of points.")]
    public Text points;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        currPlayerHealth = playerHealthMax;
        currPlayerLives = playerLivesMax;
        lives = gameObject.AddComponent<LifeVisualManager>();
        lives.SetVals(this);
        pointsManager = gameObject.AddComponent<PointManager>();

        for (int i = 0; i < playerHealthMax; i++)
        {
            lives.AddLife();
        }
    }

    public void UpdatePlayerHealth()
    {
        currPlayerHealth--;

        lives.RemoveLife();
        if(currPlayerHealth == 0 && currPlayerLives != 0)
        {
            livesText.text = "Lives: " + currPlayerLives;
            currPlayerLives--;
            for (int i = 0; i < playerHealthMax; i++)
            {
                lives.AddLife();
                currPlayerHealth++;
            }
            player.transform.position = player.GetCheckpoint();
        }
        else if (currPlayerHealth == 0 && currPlayerLives == 0)
        {
            Debug.Log("Player has died.");
            lossText.text = "You have no lives left.\nTry again?";
            lossText.gameObject.SetActive(true);
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().pauseMenu.SetActive(true);
        }
    }

    public void UpdatePoints()
    {
        pointsManager.AddPoints();
        points.text = "Points: " + pointsManager.GetPoints();
    }
}
