using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Color[] colors = {Color.red, Color.blue, Color.green}; // M?ng ch?a c�c m�u ??, l?c v� lam
    public static Color playerColor;
    void Start()
    {
        // Ch?n m?t m�u ng?u nhi�n trong m?ng colors
        int randomIndex = Random.Range(0, colors.Length);
        playerColor  = colors[randomIndex];

        // Thi?t l?p m�u cho v?t th?
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = playerColor;
    }
}
