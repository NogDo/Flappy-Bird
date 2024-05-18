using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGroundMove : MonoBehaviour
{
    #region 전역 변수
    private IEnumerator iMove;
    private IEnumerator iStop;
    private UnityEngine.Coroutine coroutineGroundMove;
    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float fMoveSpeed;

    private bool isEnd = false;

    public IEnumerator IMove
    {
        get
        {
            return iMove;
        }

        private set
        {
            iMove = value;
        }
    }

    public bool IsEnd
    {
        get
        {
            return isEnd;
        }

        private set
        {
            isEnd = value;
        }
    }
    #endregion

    void Awake()
    {
        rectTransform.localPosition = new Vector3(480, 0);
    }

    void OnEnable()
    {
        rectTransform.localPosition = new Vector3(480, 0);

        iMove = Move();
        iStop = Stop();
        coroutineGroundMove = StartCoroutine(iMove);
    }

    void OnDisable()
    {
        StopCoroutine(iMove);
    }

    IEnumerator Move()
    {
        StartCoroutine(iStop);

        while (!isEnd)
        {
            rectTransform.Translate(Vector2.left * fMoveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
        isEnd = false;
    }

    IEnumerator Stop()
    {
        yield return new WaitUntil(() => rectTransform.localPosition.x <= 0);
        isEnd = true;
    }

    public void StopMove()
    {
        StopCoroutine(iMove);
    }
}
