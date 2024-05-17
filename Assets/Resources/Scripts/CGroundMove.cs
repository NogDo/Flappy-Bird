using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGroundMove : MonoBehaviour
{
    #region 전역 변수
    private IEnumerator iMove;
    private UnityEngine.Coroutine coroutineGroundMove;
    [SerializeField]
    private RectTransform rectTransform;

    private bool isMiddle = false;
    private bool isEnd = false;

    public bool IsMiddle
    {
        get
        {
            return isMiddle;
        }

        private set
        {
            isMiddle = value;
        }
    }
    #endregion

    void OnEnable()
    {
        iMove = Move();
        coroutineGroundMove = StartCoroutine(iMove);
        rectTransform.localPosition = new Vector3(480, 0);
    }

    void OnDisable()
    {
        StopCoroutine(iMove);
    }

    IEnumerator Move()
    {
        StartCoroutine(CheckMiddle());
        StartCoroutine(Stop());

        while (!isEnd)
        {
            rectTransform.Translate(Vector2.left * 50.0f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetActive(false);
        IsMiddle = false;
        isEnd = false;
    }

    IEnumerator CheckMiddle()
    {
        yield return new WaitUntil(() => rectTransform.localPosition.x <= 0);
        isMiddle = true;
    }

    IEnumerator Stop()
    {
        yield return new WaitUntil(() => rectTransform.localPosition.x <= -480);
        isEnd = true;
    }
}
