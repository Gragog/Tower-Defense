using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Range(20, 100f)]
    public float panSpeed = 50f;
    [Range(1f, 20f)]
    public float panAccelaration = 10f;

    float currentPanSpeed;
    Vector3 targetDirection;
    Vector3 lastMovement;

    void LateUpdate()
    {
        targetDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            targetDirection.z = 1;
        if (Input.GetKey(KeyCode.DownArrow))
            targetDirection.z = -1;
        if (Input.GetKey(KeyCode.LeftArrow))
            targetDirection.x = -1;
        if (Input.GetKey(KeyCode.RightArrow))
            targetDirection.x = 1;

        if (targetDirection.z != 0 || targetDirection.x != 0)
        {
            currentPanSpeed = Mathf.Lerp(currentPanSpeed, panSpeed, Time.deltaTime * panAccelaration);
            lastMovement = targetDirection;
            transform.Translate(targetDirection.normalized * (currentPanSpeed * Time.deltaTime), Space.World);

            return;
        }

        if (currentPanSpeed > 5f)
        {
            currentPanSpeed = Mathf.Lerp(currentPanSpeed, 0f, Time.deltaTime * panAccelaration);
            transform.Translate(lastMovement.normalized * (currentPanSpeed * Time.deltaTime), Space.World);
            return;
        }

        if (currentPanSpeed != 0f)
            currentPanSpeed = 0f;
    }
}
