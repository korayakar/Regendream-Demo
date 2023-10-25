using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectingItems : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject helpPopUp;

    [Header("Sounds")]
    [SerializeField] private AudioSource collectDuckSound;
    [SerializeField] private AudioSource collectKeySound;

    [Header("Images")]
    public Image blueKeyIcon;
    public Image redKeyIcon;

    [HideInInspector] public bool isBlueKey = false;
    [HideInInspector] public bool isRedKey = false;

    [HideInInspector] public int score;

    void Start()
    {
        // Initial score is zero
        score = 0;
        scoreText.SetText(score.ToString());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Duck")
        {
            // Increase the score 
            score++;
            scoreText.SetText(score.ToString());

            // Destroying object
            Destroy(other.gameObject);

            // Collect duck sound performed
            collectDuckSound.enabled = true;
            StartCoroutine(DelayedDuckAction());
        }

        if (other.gameObject.tag == "BlueKey")
        {
            // Blue Key appears in inventory
            isBlueKey = true;
            blueKeyIcon.enabled = true;

            // Destroying object
            Destroy(other.gameObject);

            // Collect key sound performed
            collectKeySound.enabled = true;
            StartCoroutine(DelayedKeyAction());
        }

        if (other.gameObject.tag == "RedKey")
        {
            // Red key appears in inventory
            isRedKey = true;
            redKeyIcon.enabled = true;

            // Destroying object
            Destroy(other.gameObject);

            // Collect key sound performed
            collectKeySound.enabled = true;
            StartCoroutine(DelayedKeyAction());
        }
        if (other.gameObject.tag == "Book")
        {
            helpPopUp.SetActive(true);
            StartCoroutine(DelayedPopUpAction());
        }
    }
    IEnumerator DelayedDuckAction()
    {
        // To wait collect sound finish
        yield return new WaitForSeconds(2f);
        collectDuckSound.enabled = false;
    }
    IEnumerator DelayedKeyAction()
    {
        // To wait collect sound finish
        yield return new WaitForSeconds(0.4f);
        collectKeySound.enabled = false;
    }
    IEnumerator DelayedPopUpAction()
    {
        // To wait reading pop up
        yield return new WaitForSeconds(8f);
        helpPopUp.SetActive(false);
    }

}
