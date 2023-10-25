using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
    private CollectingItems doorKeys; // Reference to CollectingItems

    [Header("Doors")]
    [SerializeField] private GameObject blueDoor;
    [SerializeField] private GameObject redDoor;

    [Header("Sounds")]
    [SerializeField] private AudioSource doorOpenSound;

    [Header("VFXs")]
    [SerializeField] private GameObject bluePortalVFX;
    [SerializeField] private GameObject redPortalVFX;

    void Start()
    {
        doorKeys = FindObjectOfType<CollectingItems>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueDoor" && doorKeys.isBlueKey == true)
        {
            // Use blue key
            doorKeys.isBlueKey = false;
            doorKeys.blueKeyIcon.enabled = false;

            // Destroying object
            Destroy(other.gameObject);

            // VFX perform
            bluePortalVFX.SetActive(true);

            // Open door sound perform
            doorOpenSound.enabled = true;
            StartCoroutine(DelayedDoorAction());

        }
        if (other.gameObject.tag == "RedDoor" && doorKeys.isRedKey == true)
        {
            // Use red key
            doorKeys.isRedKey = false;
            doorKeys.redKeyIcon.enabled = false;

            // Destroying object
            Destroy(other.gameObject);

            // VFX perform
            redPortalVFX.SetActive(true);

            // Open door sound perform
            doorOpenSound.enabled = true;
            StartCoroutine(DelayedDoorAction());

        }
    }
    IEnumerator DelayedDoorAction()
    {
        // To wait door collapse
        yield return new WaitForSeconds(1.5f);
        doorOpenSound.enabled = false;
        bluePortalVFX.SetActive(false);
        redPortalVFX.SetActive(false);
    }
}
