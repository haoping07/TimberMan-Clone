using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text txtScore;
    public Image hudRed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int value)
    {
        txtScore.text = value.ToString();
    }

    public void setHud(float value)
    {
        float total = 185f;
        float pos = total - (value * total);
        hudRed.transform.localPosition = new Vector3(-pos, hudRed.transform.localPosition.y, hudRed.transform.localPosition.z);
    }

}
