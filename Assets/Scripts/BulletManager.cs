using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float speed = 5f;
    private float step;
    public float minimumDistance = 5f;
    private bool isMoving = false;
    private GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) {
            targetEnemy = findClosestEnemy();
            if (targetEnemy != null) {
                Debug.Log("Found closest Enemy");
                Vector3 targetPos = targetEnemy.transform.position;
                float distance = Vector3.Distance(transform.position, targetPos);
                Debug.Log("Calculated Distance: " + distance);
                if (distance < minimumDistance) {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
                    isMoving = true;
                }
            }
        }
        else {
            // ASSERT:  If isMoving, then targetEnemy must be defined.
            Vector3 targetPos = targetEnemy.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Entering collision with 'Enemy'");
//            collision.gameObject.SendMessage("ApplyDamage", 10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else {
            Debug.Log("Entering collision, but NOT an 'Enemy'");
        }
    }

    private GameObject findClosestEnemy() {
        Debug.Log("Looking for closest Enemy");
        GameObject[] objs= GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = 0f;
        bool first = true;
        
        foreach (var obj in objs)
        {
            Debug.Log("Looping through enemies.");
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (first)
            {
                Debug.Log("First enemy! " + distance);
                closestDistance = distance;
                closestEnemy = obj;
                
                first = false;
            }            
            else if (distance < closestDistance)
            {
                Debug.Log("NOT First enemy! " + distance);
                closestEnemy = obj;
                closestDistance = distance;
            }
            else {
                Debug.Log("NOT very close! " + distance + " > " + closestDistance);
            }
                                                                        
        }
        Debug.Log("Here's what I found:  " + closestEnemy);
        return closestEnemy;
    }
}
