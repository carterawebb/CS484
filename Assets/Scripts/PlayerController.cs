using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    public float speed;

    private int count;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        //speed = 0.0f;

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void OnMove(InputValue value) {
        Vector2 input = value.Get<Vector2>();
        
        movementX = input.x;
        movementY = input.y;
    }

    private void SetCountText() {
        countText.text = "Count: " + count.ToString();

        if (count >= 4) {
            winTextObject.SetActive(true);
        }
    }
}
