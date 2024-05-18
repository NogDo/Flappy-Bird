using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPillarMove : MonoBehaviour
{
    #region 전역 변수
    private IEnumerator iMove;
    private IEnumerator iStop;
    private UnityEngine.Coroutine coroutinePillarMove;

    [SerializeField]
    private RectTransform rectTransform;
    [SerializeField]
    private float fMoveSpeed;

    private float fMaxY = 450.0f;
    private float fMinY = -50.0f;
    private bool isEnd = false;
    #endregion

    void Awake()
    {
        rectTransform.localPosition = new Vector3(235.0f, 0.0f);
    }

    void OnEnable()
    {
        float fRandY = Random.Range(fMinY, fMaxY);
        rectTransform.localPosition = new Vector3(235.0f, fRandY);

        iMove = Move();
        iStop = Stop();
        coroutinePillarMove = StartCoroutine(iMove);
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
        yield return new WaitUntil(() => transform.localPosition.x <= -310);
        isEnd = true;
    }

    public void StopMove()
    {
        StopCoroutine(iMove);
    }
}
