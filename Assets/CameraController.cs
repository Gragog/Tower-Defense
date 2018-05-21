using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Range(20, 100f)]
    public float panSpeed = 50f;
    float targetPanSpeed;
    [Range(1f, 20f)]
    public float panAccelaration = 10f;
    [Range(1, 10)]
    public byte boostMultiplier = 2;
    [Range(0, 100)]
    public int borderForMouse = 25;

    float currentPanSpeed;
    Vector3 targetDirection;
    Vector3 lastMovement;

    void LateUpdate()
    {
        targetDirection = Vector3.zero;
        targetPanSpeed = panSpeed;

        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - borderForMouse)
            targetDirection.z = 1;
        if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= borderForMouse)
            targetDirection.z = -1;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= borderForMouse)
            targetDirection.x = -1;
        if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - borderForMouse)
            targetDirection.x = 1;
        if (Input.GetKey(KeyCode.RightShift))
            targetPanSpeed = panSpeed * boostMultiplier;

        if (targetDirection.z != 0 || targetDirection.x != 0)
        {
            currentPanSpeed = Mathf.Lerp(currentPanSpeed, targetPanSpeed, Time.deltaTime * panAccelaration);
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
