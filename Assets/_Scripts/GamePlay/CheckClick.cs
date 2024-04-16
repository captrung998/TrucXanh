using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CheckClick : MonoBehaviour
{

    [SerializeField] private int countFlip = 0;
    [SerializeField] private bool isFlip = false;


    private void Update()
    {
        Hit();
        CountFlip();


    }
    private void Hit()
    {

        if (Input.GetMouseButtonDown(0)) // Kiểm tra khi nút chuột trái được nhấn
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Lấy vị trí của chuột trong không gian thế giới 2D
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); // Kiểm tra va chạm trong không gian 2D
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (hit.collider != null && hit.collider.gameObject == gameObject) // Nếu có va chạm
            {
                if (countFlip < 2 && isFlip == false)
                {
                    isFlip = true;
                    spriteRenderer.flipX = isFlip;

                }
                else
                {
                    isFlip = false;
                    spriteRenderer.flipX = isFlip;

                }
            }
        }
    }
    private void CountFlip()
    {
        if (isFlip == true)
        {
            if (countFlip < 2) countFlip++;
            countFlip = 0;
        }
    }

}


