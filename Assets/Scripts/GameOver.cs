using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text txtScoreBest;
    public Text txtScore;
    public TapController tapController;

    public Animator anim;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void replay()
    {
        audioManager.audioButton.Play();

        tapController.reset();
        hide();
        audioManager.audioTheme.Play();
    }

    public void show()
    {
        txtScore.text = tapController.getScore().ToString();
        txtScoreBest.text = tapController.getBestScore().ToString();

        gameObject.SetActive(true);
        anim.SetBool("Panel", true);
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }
}
