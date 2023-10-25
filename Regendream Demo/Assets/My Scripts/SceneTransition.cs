using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject portalObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("LastScene");
        }
    }
}
