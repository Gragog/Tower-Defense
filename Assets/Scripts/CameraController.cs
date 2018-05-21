using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Movement")]
    [Range(20, 100f)]
    public float panSpeed = 35f;
    float targetPanSpeed;
    [Range(1f, 20f)]
    public float panAccelaration = 10f;
    [Range(0f, 50f)]
    public float scrollSpeed = 30f;
    [Range(1, 10)]
    public byte boostMultiplier = 3;
    [Range(0, 100)]
    public byte borderForMouse = 25;

    float currentPanSpeed;
    Vector3 targetDirection;
    Vector3 lastMovement;

    Vector3 camStartPosition;

    bool doMovement = true;

    void Start()
    {
        camStartPosition = transform.position;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) doMovement = !doMovement;
        if (!doMovement) return;

        targetDirection = Vector3.zero;
        targetPanSpeed = panSpeed;

        if (transform.position.z < maxZ && (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - borderForMouse))
            targetDirection.z = 1;
        if (transform.position.z > minZ && (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= borderForMouse))
            targetDirection.z = -1;
        if (transform.position.x > minX && (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= borderForMouse))
            targetDirection.x = -1;
        if (transform.position.x < maxX && (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - borderForMouse))
            targetDirection.x = 1;
        if (Input.GetKey(KeyCode.RightShift))
            targetPanSpeed = panSpeed * boostMultiplier;
        if (Input.GetMouseButtonDown(2))
            transform.position = camStartPosition;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        HandleScroll(-scroll * scrollSpeed);

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

    float currentScroll = 0f;
    [Header("Restrictions")]
    public float minY = 20f;
    public float maxY = 100f;
    public float minX = -25f;
    public float maxX = 100f;
    public float minZ = -35f;
    public float maxZ = 50f;

    void HandleScroll(float scrollAmount)
    {
        currentScroll = Mathf.Lerp(currentScroll, scrollAmount, Time.deltaTime * scrollSpeed * .2f);

        if (transform.position.y > maxY && currentScroll > 0f)
            return;
        if (transform.position.y < minY && currentScroll < 0f)
            return;

        if (currentScroll > .1f || currentScroll < -.1f)
            transform.Translate(Vector3.up * currentScroll, Space.World);
    }
}
