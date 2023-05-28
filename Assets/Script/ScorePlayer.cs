using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour
{
    private int score = 0; // Điểm số hiện tại
    public Text scoreText; // Tham chiếu đến Text GameObject

    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra va chạm với vật thể khác
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tăng điểm lên 1
            score++;

            // Cập nhật nội dung của Text GameObject
            scoreText.text = "Score: " + score;
        }
    }
}
