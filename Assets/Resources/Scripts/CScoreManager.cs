using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CScoreManager : MonoBehaviour
{
    #region 전역 변수
    [SerializeField]
    private List<Image> img_Score;
    [SerializeField]
    private List<Sprite> spt_Score;
    [SerializeField, Header("플레이어")]
    private CCharacterMove charcter;

    private IEnumerator changeScore;
    private IEnumerator setImageActiveTrue;
    private float fAddScoreTime = 5.0f;
    private int nScore = 0;
    #endregion

    void Start()
    {
        changeScore = ChangeScore();
        setImageActiveTrue = SetImageActiveTrue();

        StartCoroutine(changeScore);
        StartCoroutine(setImageActiveTrue);
        StartCoroutine(Stop());
    }

    IEnumerator ChangeScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(fAddScoreTime);

            nScore++;
            int nTempScore = nScore;

            if (nTempScore < 10)
            {
                img_Score[0].sprite = spt_Score[nTempScore % 10];
            }

            else if (nTempScore < 100)
            {
                img_Score[0].sprite = spt_Score[nTempScore / 10];
                nTempScore %= 10;
                img_Score[1].sprite = spt_Score[nTempScore % 10];
            }

            else
            {
                img_Score[0].sprite = spt_Score[nTempScore / 100];
                nTempScore %= 100;
                img_Score[1].sprite = spt_Score[nTempScore / 10];
                nTempScore %= 10;
                img_Score[2].sprite = spt_Score[nTempScore % 10];
            }
        }
    }

    IEnumerator SetImageActiveTrue()
    {
        yield return new WaitUntil(() => nScore >= 10);

        if (!img_Score[1].gameObject.activeSelf)
        {
            img_Score[1].gameObject.SetActive(true);
        }

        yield return new WaitUntil(() => nScore >= 100);

        if (!img_Score[2].gameObject.activeSelf)
        {
            img_Score[2].gameObject.SetActive(true);
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitUntil(() => charcter.IsDie);

        StopCoroutine(changeScore);
        StopCoroutine(setImageActiveTrue);
    }
}
