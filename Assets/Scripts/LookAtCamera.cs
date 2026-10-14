using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    private enum Mode
    {
        LookAt,
        LookInverted,
        cameraForward,
        cameraForwardInverted,
    }

    [SerializeField] private Mode mode;

    private void LateUpdate()
    {
        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case Mode.LookInverted:
                Vector3 dirfromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirfromCamera);
                break;
            case Mode.cameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case Mode.cameraForwardInverted:
                transform.forward = -Camera.main.transform.forward; 
                break;
        }
        
    }
}
