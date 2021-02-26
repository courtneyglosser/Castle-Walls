using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 10;
    private int currEnemies;
    
    private Vector2 screenBounds = new Vector2(-20, 7);

    public float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        currEnemies = numberOfEnemies;
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemy() {
        GameObject enemy = Instantiate (enemyPrefab) as GameObject;
        float x = screenBounds.x;
        float lowerBound = (-screenBounds.y + 1) / 2;
        float upperBound = screenBounds.y / 2;
        float y = Mathf.Floor(Random.Range(lowerBound, upperBound)) * 2 ;
        Debug.Log("Spawning at (" + x + ", " + y +")");
        enemy.transform.position = new Vector2(x, y);
    }

    IEnumerator EnemyWave() {

        while (true && currEnemies-- > 0) {
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
