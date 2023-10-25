using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Vector3 offsetRotation;

    private float smoothness = 0.125f;

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + offsetPosition;
        Quaternion targetRotation = Quaternion.Euler(offsetRotation);

        // Use Lerp to smoothly interpolate the camera position and rotation
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothness);
        Quaternion smoothRotation = Quaternion.Lerp(transform.rotation, targetRotation, smoothness);

        transform.position = smoothPosition;
        transform.rotation = smoothRotation;

        transform.LookAt(player);
    }
}
