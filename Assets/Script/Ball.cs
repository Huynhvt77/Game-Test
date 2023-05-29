using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [Header("Ball Attribute")]
    [SerializeField] float respawnDelay = 1f;
    [SerializeField] static int scorePlayer = 0;
    [SerializeField] Text scoreText;
    private float bound = 19.0f;
    MeshRenderer mr;
    [Header("Player Attribute")]
    private Color[] colors = { Color.red, Color.blue, Color.green };
    public static Color playerColor;
    Renderer renderer;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mr = GetComponent<MeshRenderer>();
        renderer = player.GetComponent<Renderer>();
        ChangeColor();
    }
    public void ChangeColor()
    {
        int randomIndex = Random.Range(0, colors.Length);
        playerColor = colors[randomIndex];

        renderer.material.color = playerColor;
    }
    public System.Action<int> OnScoreChanged { get; internal set; }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            Invoke("Respawn", respawnDelay);

            if (playerColor == mr.material.color)
            {
                scorePlayer++;
                ChangeColor(); 
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
