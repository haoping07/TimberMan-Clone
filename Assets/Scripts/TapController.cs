using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    private string direction;
    public TimberMan timberMan;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tap(string dir)
    {
        timberMan.changeDirection(dir);
        timberMan.cutAnimation();
        
        if (dir == gameManager.getDirectionFirstTrunk())
        {
            timberMan.die();
            Debug.Log("Game Over");
        }   
        else
        {
            gameManager.cutFirstTrunk();

            if (dir == gameManager.getDirectionFirstTrunk())
            {
                timberMan.die();
                Debug.Log("Game Over");
            }
        }
    }
}
