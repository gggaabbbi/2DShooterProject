using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

//responsável por cuidar das informações gerais que o player tem
//(vida, posição, se ele está tomando dano, etc)

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo instance;

    [SerializeField] private int lifes = 3;
    [SerializeField] private float playerSpeed = 10;

    //guarda informação da onde o player está
    private Transform playerTransform;
    private SpriteRenderer spriteRenderer;

    //se ele is hurt kkkk
    private bool isHurt;
    public bool isMoving;
    
    private void Awake()
    {
        //singleton = referência das informações do jogador
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerTransform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameManager.Instance.SetPlayerLife(lifes);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            LifeHandler();
        }
    }

    private void LifeHandler()
    {
        isHurt = true;
        lifes--;
        GameManager.Instance.SetPlayerLife(lifes);
        if (lifes <= 0)
        {

            Destroy(this.gameObject);
        }
    }

    public Vector2 GetPlayerPosition()
    {
        //função para pegar a posição do player
        return playerTransform.position;
    }

    public float GetPlayerSpeed ()
    {
        return playerSpeed;
    }

    public bool CheckPlayerMove()
    {
        return isMoving;
    }

    public bool CheckPlayerHurt()
    {
        return isHurt;
    }

    public void SetPlayerHurt (bool hurt)
    {
        isHurt = hurt;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
