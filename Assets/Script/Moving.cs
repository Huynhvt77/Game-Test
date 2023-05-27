// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Moving : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 10f; // Tốc độ di chuyển

    private void Update()
    {
        // Lấy input từ các phím WASD trên bàn phím
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Tính toán khoảng cách di chuyển theo trục x và trục z
        float moveX = speed * horizontalInput * Time.deltaTime;
        float moveZ = speed * verticalInput * Time.deltaTime;

        // Tạo vector di chuyển
        Vector3 moveVector = new Vector3(moveX, 0f, moveZ);

        // Di chuyển vật thể
        transform.Translate(moveVector);
    }
}

