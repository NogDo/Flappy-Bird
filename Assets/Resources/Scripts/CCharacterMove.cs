using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterMove : MonoBehaviour
{
    #region 전역 변수
    private Rigidbody2D rb2_Character = null;
    private Animator animator = null;

    [SerializeField]
    private float fJumpPower;

    private bool isDie = false;

    public bool IsDie
    {
        get
        {
            return isDie;
        }

        private set
        {
            isDie = value;
        }
    }
    #endregion

    void Awake()
    {
        rb2_Character = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDie)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2_Character.velocity = Vector2.zero;
                rb2_Character.AddForce(Vector2.up * fJumpPower);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isDie = true;
            animator.SetBool("Die", true);
            rb2_Character.bodyType = RigidbodyType2D.Static;
        }

        else if (collision.gameObject.CompareTag("Pillar"))
        {
            isDie = true;
            animator.SetBool("Die", true);
            rb2_Character.bodyType = RigidbodyType2D.Static;
        }
    }
}
