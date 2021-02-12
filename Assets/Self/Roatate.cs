using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roatate : MonoBehaviour
{
    public float xSpeed = 150.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Moved)//手指处于移动状态
                {
                    transform.Rotate(Vector3.up*(Input.GetAxis("Mouse X")*-xSpeed*Time.deltaTime),Space.World);
                    
                }
            }
        }
    }
}
