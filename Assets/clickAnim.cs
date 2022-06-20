using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickAnim : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    

    // Update is called once per frame
  public void onClick()
    {
        animator.SetBool("clicked", true);
    }
}
