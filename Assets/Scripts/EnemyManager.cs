using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    private Vector2 screenBounds = new Vector2(-20, 7);

    public float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemy() {
        GameObject enemy = Instantiate (enemyPrefab) as GameObject;
        float x = screenBounds.x;
        float y = Mathf.Floor(Random.Range(-screenBounds.y + 1, screenBounds.y));
        Debug.Log("Spawning at (" + x + ", " + y +")");
        enemy.transform.position = new Vector2(x, y);
    }

    IEnumerator EnemyWave() {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
