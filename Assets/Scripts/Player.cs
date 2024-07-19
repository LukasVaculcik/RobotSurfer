using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    // [SerializeField] private Transform GFX;
    [SerializeField] private float moveForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private float distanceToGround = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float crouchHeight = 0.5f;

    private void Update()
    {
        // Movement
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            rigidBody.velocity = Vector2.up * moveForce;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            rigidBody.velocity = Vector2.down * moveForce;
        }

        // Crouching
        // if (isGrounded && Input.GetButton("Crouch")) {
        //     GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);

        //     if (isJumping) {
        //         GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        //     }
        // }

        // if (Input.GetButtonUp("Crouch")) {
        //     GFX.localScale = new Vector3(GFX.localScale.x, 1f, GFX.localScale.z);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Obstacle")) {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }

        if (other.transform.CompareTag("Loot")) {
            Destroy(other.gameObject);
            GameManager.Instance.currentScore += 10;
        }
    }
}
