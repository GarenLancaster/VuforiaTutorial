using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Vuforia
{
    public class ARCameraControl : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var vu = VuforiaARController.Instance;
            vu.RegisterVuforiaStartedCallback(onVuStart);//ar摄像头启动时调用
            vu.RegisterOnPauseCallback(onVuPause);//暂停时调用
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void onVuStart()//完成对焦功能
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }

        void onVuPause(bool isPusae)
        {
            
        }

        void OnFoucseMode()//也可以另写一个，手动调用对焦
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }
    }
}

