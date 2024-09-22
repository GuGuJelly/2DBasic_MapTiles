using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    // SpriteRenderer 자료형은 스프라이트 이미지를 좌우 반전 시키는 변수를 만들 수 있다
    [SerializeField] SpriteRenderer render;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movePower;
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float maxFallSpeed;
    private float x;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI scoreText;

    public int score;


    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        scoreText.text = $"Gem: {score}";
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
    }

    private void Move()
    {
        // 이동방식을 rigid.velocity 방식으로 해주면 일정속도로 움직일 수 있다.
        // AddForce 방식은 점차 빨라지다가 손을 떼면 점차 느려지는 방식이라서.
        // 선택을 할 필요가 있다.
        // 조작감 개선을 위해 최고속도 설정과 최저속도 설정도 필요하다
        rigid.AddForce(Vector2.right*x*movePower, ForceMode2D.Force);
        if (rigid.velocity.x > maxMoveSpeed)
        {
            rigid.velocity = new Vector2(maxMoveSpeed, rigid.velocity.y);
        }else if (rigid.velocity.x < -maxMoveSpeed)
        {
            // -방향의 최고속도 설정
            rigid.velocity = new Vector2(-maxMoveSpeed, rigid.velocity.y);
        }

        //if (rigid.velocity.y < -maxFallSpeed)
        //{
        //    rigid.velocity = new Vector2(-maxMoveSpeed, rigid.velocity.y);
        //}
        

        if (x < 0)
        {
            // 왼쪽으로 몸을 반전시켜서 왼쪽으로 걸어가기
            render.flipX = true;
        }else if (x > 0)
        {
            // 오른쪽으로 몸을 반전시켜서 오른쪽으로 걸어가기
            render.flipX=false;
        }
    }

    private void Jump()
    {
        rigid.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
    }

    

}
