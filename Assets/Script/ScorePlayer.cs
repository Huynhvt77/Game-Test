using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    private int score = 0; // Điểm số hiện tại

    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra va chạm với vật thể khác
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tăng điểm lên 1
            score++;

            // In ra điểm số ở góc camera
            Debug.Log("Điểm số: " + score, Camera.main.gameObject);
        }
    }
}
