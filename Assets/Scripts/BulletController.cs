using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
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
                Vector3 targetPos = targetEnemy.transform.position;
                float distance = Vector3.Distance(transform.position, targetPos);
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
//            collision.gameObject.SendMessage("ApplyDamage", 10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private GameObject findClosestEnemy() {
        GameObject[] objs= GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = 0f;
        bool first = true;
        
        foreach (var obj in objs)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (first)
            {
                closestDistance = distance;
                closestEnemy = obj;
                
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
