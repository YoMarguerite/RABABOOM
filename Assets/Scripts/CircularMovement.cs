using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    float timeCounter = 0;
    public float variantSpeed;
    public float speed;
    public float width;
    public float height;

    void Update()
    {
        var speedActual = Random.Range(speed - variantSpeed, speed + variantSpeed);
        timeCounter += Time.deltaTime * speedActual;

        float x = Mathf.Cos(timeCounter)*width;
        float y = Mathf.Sin(timeCounter)*height;

        transform.localPosition = new Vector3(x, transform.localPosition.y, -y);

        float angle = Mathf.Atan2(transform.localPosition.x, transform.localPosition.z) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, angle, 0);

    }
}
