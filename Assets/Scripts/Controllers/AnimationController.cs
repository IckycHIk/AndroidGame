using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    //AnimationNaming
    private const string movingBool = "move";





    private Animator animator;




    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }





    public void setMoveAnim(bool isMove) {


        animator.SetBool(movingBool, isMove);


    }


}
