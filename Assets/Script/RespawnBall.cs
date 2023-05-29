using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnBall : MonoBehaviour
{
    public float respawnDelay = 1f; // Thời gian chờ để vật thể xuất hiện lại
    private Vector3 initialPosition; // Vị trí ban đầu của vật thể
    public static int scorePlayer = 0;
    MeshRenderer mr;
    private void Start()
    {
        initialPosition = transform.position; // Lưu vị trí ban đầu của vật thể
        mr = GetComponent<MeshRenderer>();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra va chạm với vật thể khác
        if (collision.gameObject.CompareTag("Player"))
        {
            // Vô hiệu hóa vật thể
            gameObject.SetActive(false);
            // Gọi hàm để vật thể xuất hiện lại sau một khoảng thời gian
            Invoke("Respawn", respawnDelay);

            if (RandomColor.playerColor == mr.material.color)
            {
                scorePlayer++;
                Debug.Log("Score: " + scorePlayer);
                if (scorePlayer == 10)
                    WinStatus();
            }
            else
            {
                DefeatStatus();
            }
            
        }
    }

    void WinStatus()
    {
        SceneManager.LoadScene("WinScene");
    }

    void DefeatStatus()
    {
        SceneManager.LoadScene("LoseScene");
    }
    private void Respawn()
    {
        // Đặt lại vị trí của vật thể
        transform.position = GetRandomPosition();

        // Kích hoạt vật thể
        gameObject.SetActive(true);
    }

    private Vector3 GetRandomPosition()
    {
        // Lấy ngẫu nhiên vị trí mới trên mặt phẳng (plane)
        // Bạn có thể tùy chỉnh giới hạn và cách lấy vị trí ngẫu nhiên tại đây
        Vector3 randomPosition = new Vector3(Random.Range(-4f, 4f), 0.5f, Random.Range(-4f, 4f));
        return randomPosition;
    }
}
