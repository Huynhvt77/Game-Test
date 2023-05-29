using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] float respawnDelay = 1f;
    [SerializeField] int scorePlayer = 0;
    [SerializeField] Text scoreText;
    private float bound = 19.0f;
    MeshRenderer mr;
    
    public System.Action<int> OnScoreChanged { get; internal set; }

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            Invoke("Respawn", respawnDelay);

            if (RandomColor.playerColor == mr.material.color)
            {
                scorePlayer++;
                if (scorePlayer == 10)
                    WinStatus();
                else
                    scoreText.text = scorePlayer.ToString();
            }
            else
            {
                DefeatStatus();
            }
        }
    }

    private void WinStatus()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
    }

    private void DefeatStatus()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScene");
    }
    private void Respawn()
    {
        transform.position = GetRandomPosition();
        gameObject.SetActive(true);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-bound, bound), 0.5f, Random.Range(-bound, bound));
        return randomPosition;
    }
}
