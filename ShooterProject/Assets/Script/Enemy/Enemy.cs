using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity = 5;
    private int lives;
    private Transform enemyTransform;
    private Vector2 targetPosition;

    private void Awake()
    {
        enemyTransform = GetComponent<Transform>();
    }

    void Start()
    {
    }

    
    void Update()
    {
        //enemyTransform.Translate(targetPosition * velocity *Time.deltaTime);
        targetPosition = PlayerInfo.instance.GetPlayerPosition();
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, velocity * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit " + collision.collider.tag);
        if (collision.collider.tag == "Bullet")
        {
            GameManager.instance.SetGameScore(1);
            Destroy(this.gameObject);
        }
    }
}
