using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private Color[] colors = {Color.red, Color.blue, Color.green}; 
    public static Color playerColor;
    void Start()
    {
        int randomIndex = Random.Range(0, colors.Length);
        playerColor = colors[randomIndex];

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = playerColor;
    }
}
