using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterMove : MonoBehaviour
{
    #region ���� ����
    private Rigidbody2D rb2_Character = null;

    [SerializeField]
    private float fJumpPower;
    #endregion

    void Awake()
    {
        rb2_Character = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2_Character.velocity = Vector2.zero;
            rb2_Character.AddForce(Vector2.up * fJumpPower);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("���� ����");
        //Time.timeScale = 0;
    }
}
