using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float speed = 10f; 

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float moveX = speed * horizontalInput * Time.deltaTime;
        float moveZ = speed * verticalInput * Time.deltaTime;

        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);

        transform.Translate(moveVector);
    }
}

