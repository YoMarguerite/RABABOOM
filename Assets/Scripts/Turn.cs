using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    //Rigidbody rigid;

    //[SerializeField]
    //[Range(0f, 360)]
    //float maxRotation = 15;

    //[SerializeField]
    //[Range(0f, 360f)]
    //float minRotation = 360 - 15;

    //[SerializeField]
    //float speedTurn = 1;

    //[SerializeField]
    //float speedWave = 1;

    //float goalRotation = 0;
    //int directionWave = 1;
    // Start is called before the first frame update
    void Start()
    {
        //rigid = GetComponent<Rigidbody>();
        //rigid.angularVelocity = new Vector3(0, speedTurn, 0);
        //goalRotation = maxRotation;
    }

    void FixedUpdate()
    {
        //var angle = transform.eulerAngles.z;
        //print(angle);

        //if (Mathf.Floor(angle) == goalRotation)
        //{
        //    directionWave = -directionWave;

        //    if(goalRotation == maxRotation)
        //        goalRotation = minRotation;

        //    if (goalRotation == minRotation)
        //        goalRotation = maxRotation;
        //}

        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z + speedWave * directionWave * Time.deltaTime * Time.timeScale);
    }
}