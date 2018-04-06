using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyController : GameStateObserver<MyController> {
    [SerializeField] private float m_MaxSpeed = 10f;
    [Header("Jump")]
    [SerializeField] private float m_JumpForce= 8f;
    private Rigidbody2D m_Rigidbody2D;

    private bool m_Jump;
    [SerializeField] private Transform m_groundCheck;
    private float m_groundRadius = 0.2f;
    private bool m_Grounded;
    [SerializeField] private LayerMask whatIsGround;


    protected override void Awake()
    {
        base.Awake();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    protected override void GamePlay()
    {
        m_CanPlay = true;
    }

    private void FixedUpdate()
    {
        if (!m_CanPlay) return;
        m_Jump = Input.GetKeyDown(KeyCode.Space);
        
        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundCheck.position, m_groundRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        float move = Input.GetAxis("Horizontal");

        if (m_Grounded)
        {
            m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
        }

    }

    private void Update()
    {
        if (!m_CanPlay) return;
        if (m_Grounded && m_Jump)
        {
            m_Rigidbody2D.velocity = Vector2.up * m_JumpForce;
        }
        m_Grounded = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Loose")
        {
            GameManager.Instance.LooseGame();
        } else if (collision.gameObject.tag == "Win")
        {
            GameManager.Instance.WinGame();
        }
        
    }
}
