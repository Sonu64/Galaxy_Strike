using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField] float controlSpeed = 10.0f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;



    Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        ProcessTranslation();
    }

    private void ProcessTranslation() {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);

    }

    public void OnMove(InputValue value) {
        Debug.Log(value.Get<Vector2>());
        movement = value.Get<Vector2>();
    }
}
