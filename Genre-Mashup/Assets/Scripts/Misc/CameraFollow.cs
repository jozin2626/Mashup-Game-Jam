using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public float xScale, yScale;

    void Update()
    {
        this.transform.position = new Vector3(playerPos.position.x * xScale, playerPos.position.y * yScale, this.transform.position.z);
    }
}
