using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help_RotationScanner : MonoBehaviour
{
    public GameObject rb;
    public GameObject startOb;
    public float distanceChanged;
    
    public Vector3 upDifference;
    public float upDifferenceMagnitude;
    
    public float yDifference;

    public float differenceTolerance;

    public bool angleDifference, hightDifference;
    
    private Vector3 _vn,_vp;
    // Start is called before the first frame update
    void Start()
    {
        distanceChanged = 0;
        _vn = new Vector3();
        _vp = new Vector3();
        upDifference = new Vector3();
        angleDifference = hightDifference = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        _vn = rb.transform.position - startOb.transform.position;
        distanceChanged = _vn.magnitude-_vp.magnitude;
        
        upDifference = rb.transform.up - startOb.transform.up;
        upDifferenceMagnitude = upDifference.magnitude;
        
        yDifference = Math.Abs(rb.transform.position.y - startOb.transform.position.y);

        
        //如果角度差和高度差在容忍范围内，就把他们设成true
        if (upDifferenceMagnitude<differenceTolerance)
            angleDifference = true;
        else
        {
            angleDifference = false;
        }
        if (yDifference < differenceTolerance)
            hightDifference = true;
        else
        {
            hightDifference = false;
        }
        _vp = _vn;
    }
}
