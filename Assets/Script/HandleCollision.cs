using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollision : MonoBehaviour
{

    private int score = 0; // Điểm số hiện tại

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";

            // Tăng điểm lên 1
            score++;

            // In ra điểm số ở góc camera
            Debug.Log("Điểm số: " + score, Camera.main.gameObject);
        }
    }
}
