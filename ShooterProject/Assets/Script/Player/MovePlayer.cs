using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//respons�vel por cuidar da movimenta��o do player baseado no input do usu�rio (que tecla ele apertou) 

public class MovePlayer : MonoBehaviour
{
    private float speed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        speed = PlayerInfo.instance.GetPlayerSpeed();
        spriteRenderer = PlayerInfo.instance.GetSpriteRenderer();
    }

    void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        //movimenta��o
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(moveX, moveY).normalized * speed * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;
        FlipSprite(moveX);

        //rodar a fun��o do move
        //if (moveX != 0 || moveY != 0)
        //{
        //    isMoving = true;
        //}
        //else
        //{
        //    isMoving = false;
        //}
        //outra alternativa abaixo:
        //isMoving = moveX != 0 || moveY != 0;
    }

    //fun��o para virar a anima��o do personagem ao se movimentar de um lado para o outro
    private void FlipSprite(float moveX)
    {
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveX > 0) 
        {
            spriteRenderer.flipX = false;
        }
        
    }
}
