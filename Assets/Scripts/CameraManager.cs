using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float smoothing = 1f;

    public Vector2 minPosition;
    public Vector2 maxPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxisRaw("Horizontal");
        float ySpeed = Input.GetAxisRaw("Vertical");

        if (xSpeed != 0) {
            Debug.Log("Registered Horizontal: " + xSpeed);
        }
        if (ySpeed != 0) {
            Debug.Log("Registered Vertical: " + ySpeed);
        }

        Vector2 inputVector = new Vector2(xSpeed, ySpeed).normalized;
        inputVector = inputVector * speed * Time.deltaTime;

        float x = transform.position.x + inputVector.x;
        float y = transform.position.y + inputVector.y;
        float z = transform.position.z;
        x = Mathf.Clamp(x, minPosition.x, maxPosition.x);
        y = Mathf.Clamp(y, minPosition.y, maxPosition.y);
        Vector3 targetPosition = new Vector3(x, y, z);
//        transform.position = new Vector3(x, y, z);
        // Don't set directly to player position.  Introduce smoothing.
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
    }
}
