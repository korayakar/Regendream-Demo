using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private AnimationController animationController;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Button attackButton;
    [SerializeField] private GameObject slashVFX;
    
    [Header("Sounds")]
    [SerializeField] private AudioSource footstepsSound;
    [SerializeField] private AudioSource attackSound;

    private float horizontal;
    private float vertical;

    private void Start()
    {
        animationController = GetComponent<AnimationController>();
    }
    private void Update()
    {
        GetMovementInputs();
    }

    private void FixedUpdate()
    {
        SetMovement();
        SetRotation();
    }
    private void Awake()
    {
        // Attack animation when pressed "Attack" button
        attackButton.onClick.AddListener(Attack);
    }

    private void SetMovement()
    {
        playerRigidbody.velocity = GetNewVelocity();
    }

    private void SetRotation()
    {
        if (horizontal != 0 || vertical != 0)
        {
            // If joystick is using
            playerTransform.rotation = Quaternion.LookRotation(GetNewVelocity());
            animationController.SetBoolean("isRunning", true);
            footstepsSound.enabled = true;
        }
        else
        {
            // Stop using joystick
            animationController.SetBoolean("isRunning", false);
            footstepsSound.enabled = false;
        }
    }

    private Vector3 GetNewVelocity()
    {
        return new Vector3(x: horizontal, playerRigidbody.velocity.y, z: vertical) * moveSpeed * Time.fixedDeltaTime;
    }

    private void GetMovementInputs()
    {
        // Getting inputs from joystick
        horizontal = fixedJoystick.Horizontal;
        vertical = fixedJoystick.Vertical;
    }

    public void Attack()
    {
        // Play attack animation
        animationController.SetState("Attack");
        attackSound.enabled = true;
        StartCoroutine(DelayedAction());

        slashVFX.SetActive(true);
    }
    IEnumerator DelayedAction()
    {
        // To wait attack animation
        yield return new WaitForSeconds(0.7f);
        attackSound.enabled = false;
        slashVFX.SetActive(false);

    }
}
