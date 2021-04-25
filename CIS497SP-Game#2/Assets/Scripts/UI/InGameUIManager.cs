using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    private LifeVisualManager lives;

    private PointManager pointsManager;

    private int playerHealthMax = 3;
    private int currPlayerHealth;

    [Tooltip("Text display number of points.")]
    public Text points;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

        currPlayerHealth = playerHealthMax;
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

        if (currPlayerHealth == 0)
        {
            Debug.Log("Player has died.");
            Time.timeScale = 0;
        }
    }

    public void UpdatePoints()
    {
        pointsManager.AddPoints();
        points.text = "Points: " + pointsManager.GetPoints();
    }
}
