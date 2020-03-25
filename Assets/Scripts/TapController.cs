using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    private string direction;
    public TimberMan timberMan;

    private GameManager gameManager;
    public GameObject canvas;
    public GameObject canvasGameOver;
    public GameObject canvasMenu;

    private UIController uiController;

    public GameOver gameOver;

    private int score = 0;
    private int bestScore = 0;

    public int getScore()
    {
        return score;
    }

    public int getBestScore()
    {
        return bestScore;
    }

    private float totalTime = 5.0f;
    private float currentTime;
    private bool isGameOver;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = true;

        gameManager = GetComponent<GameManager>();
        uiController = GetComponent<UIController>();

        currentTime = totalTime;

        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.audioTheme.Play();
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
            GameOver();
        }
    }

    public void Tap(string dir)
    {
        if (isGameOver) return;

        timberMan.changeDirection(dir);
        timberMan.cutAnimation();
        
        if (dir == gameManager.getDirectionFirstTrunk())
        {
            GameOver();
            //Debug.Log("Game Over");
        }   
        else
        {
            gameManager.cutFirstTrunk(dir);

            if (dir == gameManager.getDirectionFirstTrunk())
            {
                GameOver();
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

    public void reset()
    {
        isGameOver = false;
        score = 0;
        uiController.setScore(0);

        currentTime = totalTime;
        uiController.setHud(1);

        timberMan.respawn();
        gameManager.reset();

        canvas.gameObject.SetActive(true);

        audioManager.GetComponent<AudioSource>().Play();
    }

    public void Play()
    {
        reset();
        canvasMenu.gameObject.SetActive(false);
        audioManager.audioButton.Play();
    }

    public void GameOver()
    {
        audioManager.audioTheme.Stop();

        canvas.SetActive(false);
        isGameOver = true;
        timberMan.die();
        if (bestScore < score)
        {
            bestScore = score;
        }
        gameOver.show();

    }
}
