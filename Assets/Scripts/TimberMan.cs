using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimberMan : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;

    private string dir;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeDirection(string direction)
    {
        if (direction == "LEFT")
        {
            transform.localPosition = new Vector3(-2.66f, transform.position.y, transform.position.z);
            sprite.flipX = false;
        }
        else
        {
            transform.localPosition = new Vector3(2.66f, transform.position.y, transform.position.z);
            sprite.flipX = true;
        }
        dir = direction;

    }

    public void cutAnimation()
    {
        anim.Play("Cut", 0, 0);
    }

    public void die()
    {
        sprite.flipX = false;

        if (dir == "LEFT")
        {
            transform.localPosition = new Vector3(-3.35f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.localPosition = new Vector3(3.52f, transform.position.y, transform.position.z);
        }
        anim.Play("Die", 0, 0);
    }
}
