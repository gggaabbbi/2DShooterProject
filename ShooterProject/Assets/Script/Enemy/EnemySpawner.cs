using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Vector2 minSpawnPosition, maxSpawnPosition;
    [SerializeField] GameObject enemyDino;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies() 
    {
        while (true) 
        {  
        yield return new WaitForSeconds(1f);
        float xPosition = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
        float yPosition = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
        Instantiate(enemyDino, new Vector2(xPosition, yPosition),
            Quaternion.identity);
        }
    }
}
