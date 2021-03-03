using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int stoneInventory = 20;
    private int currEnemies;
    
    private Vector2 screenBounds = new Vector2(-20, 7);

    public float waitTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ManTheWalls());
    }

    private void LoadSling() {
        GameObject bullet = Instantiate (bulletPrefab) as GameObject;
        bullet.transform.position = new Vector2(2, 2);
        stoneInventory--;
    }

    IEnumerator ManTheWalls() {

        while (true && stoneInventory > 0) {
            yield return new WaitForSeconds(waitTime);
            LoadSling();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
