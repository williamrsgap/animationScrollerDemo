using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion2DScroller : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 2.0f;
    bool idle = true; // Am I currently in idle state?
    Animator myAnimator;   // Link to animator component (and therefore to parameters)

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0;
        float dy = 0;

        if (!Input.anyKey && !idle) // Is no key down and not in idle state
        {
            myAnimator.SetTrigger("idle");
            idle = true;
        }
        if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow)) // Move west now
        {
            dx = -1;
            myAnimator.SetTrigger("left"); // Fire west trigger in animator (switching to WalkWest state)
            idle = false;

        }
        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow)) // Move east now
        {
            dx = 1;
            myAnimator.SetTrigger("right"); // Fire east trigger in animator (switching to WalkEast state)
            idle = false;
        }
        if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) // Move west now
        {
            dy = 1; //Jump Function
            myAnimator.SetTrigger("up"); // Fire west trigger in animator (switching to WalkNorth state)
            idle = false;
        }
        if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow)) // Move west now
        {
            dy = -1;
            myAnimator.SetTrigger("down"); // Fire west trigger in animator (switching to WalkSouth state)
            idle = false;
        }

        Vector2 del = new Vector2(dx, dy);
        del.Normalize();
        rb.position += del * Time.deltaTime * speed;
    }
}
