using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//respons�vel por cuidar das anima��es do player
//baseado nos estados do player (isMoving, isHurt)'

public class AnimatePlayer : MonoBehaviour
{
    private Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimationHandler();
    }

    private void AnimationHandler()
    {
        //verifica��o se est� machucado
        bool isMovingAnimation = animator.GetBool("isMoving");
        bool isHurtAnimation = animator.GetBool("isHurt");
        bool isMoving = PlayerInfo.instance.isMoving;
        bool isHurt = PlayerInfo.instance.CheckPlayerHurt();

        //verifica��o se est� se mexendo
        if (isMoving && isMovingAnimation == false)
        {
            animator.SetBool("isMoving", true);
        }
        else if (!isMoving && isMovingAnimation == true)
        {
            animator.SetBool("isMoving", false);
        }

        if (isHurt && isHurtAnimation == false)
        {
            animator.SetBool("isHurt", true);
            PlayerInfo.instance.SetPlayerHurt(false);
        }
        else if (!isHurt && isHurtAnimation == true)
        {
            animator.SetBool("isHurt", false);
        }
    }


}
