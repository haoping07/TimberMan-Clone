using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    private string direction;
    public TimberMan timberMan;

    private GameManager gameManager;

    private UIController uiController;


    private int score = 0;

    private float totalTime = 5.0f;
    private float currentTime;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        uiController = GetComponent<UIController>();

        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        uiController.setHud(currentTime / totalTime);

        if (currentTime <= 0)
        {
            Debug.Log("Game Over");
            isGameOver = true;
            timberMan.die();
        }
    }

    public void Tap(string dir)
    {
        if (isGameOver) return;

        timberMan.changeDirection(dir);
        timberMan.cutAnimation();
        
        if (dir == gameManager.getDirectionFirstTrunk())
        {
            timberMan.die();
            isGameOver = true;
            //Debug.Log("Game Over");
        }   
        else
        {
            gameManager.cutFirstTrunk();

            if (dir == gameManager.getDirectionFirstTrunk())
            {
                timberMan.die();
                isGameOver = true;
                //Debug.Log("Game Over");
            }
            else
            {
                score++;
                uiController.setScore(score);
                currentTime += 0.25f;
            }
        }
    }
}
