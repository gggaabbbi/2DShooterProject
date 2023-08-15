using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float velocity = 10;
    [SerializeField] private int lives = 3;

    private Animator animator;
    private Transform playerTransform;

    public static Player instance;

    private bool isMoving;
    private bool isHurt;

    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        //final do singleton

        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }

    void Update()
    {
        MoveHandler();
        LifeHandler();
        AnimationHandler();
    }

    #region Handlers
    private void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(moveX, moveY, 0);
        if (moveX != 0 || moveY != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //outra alternativa abaixo:
        //isMoving = moveX != 0 || moveY != 0;
    }

    private void LifeHandler()
    {
        if(lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void AnimationHandler()
    {
        bool isMovingAnimation = animator.GetBool("isMoving");
        bool isHurtAnimation = animator.GetBool("isHurt");

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
            isHurt = false;
        }
        else if  (!isHurt && isHurtAnimation == true)
        {
            animator.SetBool("isHurt", false);
        }
    }
    #endregion
    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
        isHurt = true;
        print(lives);
    }
}
