
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}
