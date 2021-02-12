using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private Vector2 pos1;

    private Vector2 pos2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2)
        {
            //任意一只手指在移动
            if (Input.GetTouch(0).phase == TouchPhase.Moved ||
                Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                Vector2 tpos1 = Input.GetTouch(0).position;//获得手指位置
                Vector2 tpos2 = Input.GetTouch(1).position;
                if (isEnlarge(pos1, pos2, tpos1, tpos2))//判断是变大还是变小
                {
                    float scale = transform.localScale.x*1.25f;
                    transform.localScale = new Vector3(scale, scale, scale);
                }
                else
                {
                    float scale = transform.localScale.x/1.25f;
                    transform.localScale = new Vector3(scale, scale, scale);
                }
                pos1 = tpos1;
                pos2 = tpos2;
            }
        }
        
    }

    //传入这次手指位置与上次手指位置，返回变大还是变小
    bool isEnlarge(Vector2 op1,Vector2 op2,Vector2 np1,Vector2 np2)
    {
        float len1 = Mathf.Abs(op1.x - op2.x) + Mathf.Abs(op1.y - op2.y);
        float len2 = Mathf.Abs(np1.x - np2.x) + Mathf.Abs(np1.y - np2.y);
        if (len1 < len2)
            return true;
        return false;
    }
}
