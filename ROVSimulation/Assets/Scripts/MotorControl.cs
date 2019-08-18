using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorControl : MonoBehaviour
{
    [SerializeField] private float thrustSpeed = 0f;
    [SerializeField] private float servoSpeed = 0f;
    [SerializeField] private float motorDelay = 0f;

    [SerializeField] private List<string> keysForward;
    [SerializeField] private List<string> keysBackward;
    [SerializeField] private List<string> keysUp;
    [SerializeField] private List<string> keysDown;
    
    [SerializeField] private GameObject propeller;
    
    private bool isThrusting;
    private bool applyFixedThrust;
    private bool isCoroutineRunning;
    private Rigidbody rig;



    IEnumerator applyThrust()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(motorDelay);
        while (isThrusting)
        {
            applyFixedThrust = true;
            yield return null;
        }

        applyFixedThrust = false;
        isCoroutineRunning = false;
    }


    private void Start()
    {
        rig = transform.parent.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(applyFixedThrust)
        {
            rig.AddForce(transform.forward * thrustSpeed);
            propeller.transform.Rotate(new Vector3(0, 0, 1),Time.deltaTime * thrustSpeed * 250f);
        }
    }

    private void Update()
    {
        bool isThereAnyButtonDown = false;

        foreach(string key in keysForward)
        {
            if(Input.GetKey(key))
            {
                transform.rotation = Quaternion.Lerp
                (
                    transform.rotation,
                    Quaternion.LookRotation
                    (
                        transform.parent.forward,
                        transform.parent.right
                    ),
                    servoSpeed * Time.deltaTime
                );

                isThrusting = true;
                if(!isCoroutineRunning)
                {
                    StartCoroutine(applyThrust());
                }
                isThereAnyButtonDown = true;
                break;
            }
        }

        foreach (string key in keysBackward)
        {
            if (Input.GetKey(key))
            {
                transform.rotation = Quaternion.Lerp
                (
                    transform.rotation,
                    Quaternion.LookRotation
                    (
                        -transform.parent.forward,
                        transform.parent.right
                    ),
                    servoSpeed * Time.deltaTime
                );

                isThrusting = true;
                if (!isCoroutineRunning)
                {
                    StartCoroutine(applyThrust());
                }
                isThereAnyButtonDown = true;
                break;
            }
        }

        foreach (string key in keysUp)
        {
            if (Input.GetKey(key))
            {
                transform.rotation = Quaternion.Lerp
                (
                    transform.rotation,
                    Quaternion.LookRotation
                    (
                        transform.parent.up,
                        transform.parent.right
                    ),
                    servoSpeed * Time.deltaTime
                );

                isThrusting = true;
                if (!isCoroutineRunning)
                {
                    StartCoroutine(applyThrust());
                }
                isThereAnyButtonDown = true;
                break;
            }
        }

        foreach (string key in keysDown)
        {
            if (Input.GetKey(key))
            {
                transform.rotation = Quaternion.Lerp
                (
                    transform.rotation,
                    Quaternion.LookRotation
                    (
                        -transform.parent.up,
                        transform.parent.right
                    ),
                    servoSpeed * Time.deltaTime
                );

                isThrusting = true;
                if (!isCoroutineRunning)
                {
                    StartCoroutine(applyThrust());
                }
                isThereAnyButtonDown = true;
                break;
            }
        }

        if (!isThereAnyButtonDown)
        {
            isThrusting = false;
        }


    }
}
