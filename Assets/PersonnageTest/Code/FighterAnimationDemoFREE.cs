using UnityEngine;
using System.Collections;

public class FighterAnimationDemoFREE : MonoBehaviour
{

    public Animator animator;

    void Start()
    {
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Walk Forward", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Walk Forward", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Walk Forward", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Walk Forward", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Walk Backward", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))

        {
            animator.SetBool("Walk Backward", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("Walk Backward", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))

        {
            animator.SetBool("Walk Backward", false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("PunchTrigger");
        }
    }
}