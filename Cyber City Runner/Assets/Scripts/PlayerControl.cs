using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    public float runMultiplier = 2.0f;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    /*
     * Citation for charactor contoller script 
     * https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
     */

    void Update()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float currentSpeed = isRunning ? speed * runMultiplier : speed;

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        characterController.Move(movementDirection * currentSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    // if the user comes in contact with the level change box
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LevelChange"))
        {
            // if last level the user will be taken to the main menu
            if (SceneManager.GetActiveScene().buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
            {
                ReturnToMainMenu();
            }
            else
            {
                // next level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
    // takes user to main menu

    void ReturnToMainMenu()
        {
        SceneManager.LoadScene("MainMenu");
        }

}
