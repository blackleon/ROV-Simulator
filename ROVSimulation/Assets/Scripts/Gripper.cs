using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gripper : MonoBehaviour
{
    [SerializeField] private float servoSpeed = 10f;
    [SerializeField] private float direction;

    Vector3 TargetVector;
    bool rotating;
    bool rotateTheGrip;
    bool isGripperClosed;

    IEnumerator gripRotate()
    {
        while(rotateTheGrip)
        {
            rotating = true;
            transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    Quaternion.LookRotation(TargetVector),
                    servoSpeed * Time.deltaTime);

            if(transform.rotation == Quaternion.LookRotation(TargetVector))
            {
                rotateTheGrip = false;
            }
            yield return null;
        }
        rotating = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isGripperClosed)
            {
                TargetVector = transform.parent.forward * 5 + transform.parent.right * direction;
                rotateTheGrip = true;
                isGripperClosed = true;
                if(!rotating)
                {
                    StartCoroutine(gripRotate());
                }
            }
            else
            {
                TargetVector = transform.parent.forward * 2 + transform.parent.right * -direction;
                rotateTheGrip = true;
                isGripperClosed = false;
                if (!rotating)
                {
                    StartCoroutine(gripRotate());
                }
            }
        }
    }
}
