using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speed = 5f;
    public float minimumDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject targetEnemy = findClosestEnemy();
        Vector3 targetPos = targetEnemy.transform.position;
        float distance = Vector3.Distance(transform.position, targetPos);
        if (distance < minimumDistance) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Entering collision with 'Enemy'");
            collision.gameObject.SendMessage("ApplyDamage", 10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else {
            Debug.Log("Entering collision, but NOT an 'Enemy'");
        }
    }

    private GameObject findClosestEnemy() {
        GameObject[] objs= GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = 100f;
        bool first = true;
        
        foreach (var obj in objs)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (first)
            {
                closestDistance = distance;
                
                first = false;
            }            
            else if (distance < closestDistance)
            {
                closestEnemy = obj;
                closestDistance = distance;
            }
                                                                        
        }
        return closestEnemy;
    }
}
