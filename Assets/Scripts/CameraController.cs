using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camTarget;
    private Vector3 newPosition;

    // Update is called once per frame
    void Update()
    {
        // Check if the target is not null
        if (camTarget != null) 
        {
            newPosition = this.transform.position;
            newPosition.x = camTarget.transform.position.x;
            newPosition.z = camTarget.transform.position.z;
            this.transform.position = newPosition;
        }
    }
}
