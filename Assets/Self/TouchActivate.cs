using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchActivate : MonoBehaviour
{
    //------长按---------------
    private float touchTime;
    private bool newTouch;
    //-------------------------
    // Start is called before the first frame update
    void Start()
    {
        newTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//发生触摸
        {
            if (Camera.main is { })
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//从摄像机向点击的位置发射射线
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))//如果发射碰撞就返回，返回信息都在hitInfo里
                {
    
                    // //双击删除
                    // if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)//单手指且第一次触摸
                    // {
                    //if(Input.GetTouch(0).tapCount==2)//双击
                    //     Destroy(hitInfo.collider.gameObject);//销毁碰撞到的物体
                    // }
                    
                    //------长按删除---------------
                    if (Input.touchCount == 1)//1只手指触摸的
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began)//第一次按，就记录一次时间
                        {
                            newTouch = true;
                            touchTime = Time.time;
                        }
                        else if (touch.phase == TouchPhase.Stationary)//处于按住状态
                        {
                            if (newTouch == true && Time.time - touchTime > 2)//当时间大于2秒，就删除
                            {
                                newTouch = false;
                                Destroy(hitInfo.collider.gameObject);
                            }
                        }
                        else
                        {
                            newTouch = false;
                        }
                    }
                    //----------------------------
                }
            }
        }
        
        
    }
} 
