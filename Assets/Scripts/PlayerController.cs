using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    // SpriteRenderer �ڷ����� ��������Ʈ �̹����� �¿� ���� ��Ű�� ������ ���� �� �ִ�
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
        // �̵������ rigid.velocity ������� ���ָ� �����ӵ��� ������ �� �ִ�.
        // AddForce ����� ���� �������ٰ� ���� ���� ���� �������� ����̶�.
        // ������ �� �ʿ䰡 �ִ�.
        // ���۰� ������ ���� �ְ�ӵ� ������ �����ӵ� ������ �ʿ��ϴ�
        rigid.AddForce(Vector2.right*x*movePower, ForceMode2D.Force);
        if (rigid.velocity.x > maxMoveSpeed)
        {
            rigid.velocity = new Vector2(maxMoveSpeed, rigid.velocity.y);
        }else if (rigid.velocity.x < -maxMoveSpeed)
        {
            // -������ �ְ�ӵ� ����
            rigid.velocity = new Vector2(-maxMoveSpeed, rigid.velocity.y);
        }

        //if (rigid.velocity.y < -maxFallSpeed)
        //{
        //    rigid.velocity = new Vector2(-maxMoveSpeed, rigid.velocity.y);
        //}
        

        if (x < 0)
        {
            // �������� ���� �������Ѽ� �������� �ɾ��
            render.flipX = true;
        }else if (x > 0)
        {
            // ���������� ���� �������Ѽ� ���������� �ɾ��
            render.flipX=false;
        }
    }

    private void Jump()
    {
        rigid.AddForce(Vector2.up*jumpPower, ForceMode2D.Impulse);
    }

    

}
