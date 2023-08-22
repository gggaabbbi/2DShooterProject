using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//responsável por cuidar da movimentação do player baseado no input do usuário (que tecla ele apertou) 

public class MovePlayer : MonoBehaviour
{
    private float speed;

    void Start()
    {
        speed = PlayerInfo.instance.GetPlayerSpeed();
    }

    void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        //movimentação
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(moveX, moveY).normalized * speed * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;

        //rodar a função do move
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
}
