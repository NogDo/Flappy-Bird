using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIManager : MonoBehaviour
{
    #region 전역 변수
    [SerializeField]
    private GameObject objTextRestart;
    [SerializeField, Header("플레이어")]
    private CCharacterMove charcter;
    #endregion

    void Start()
    {
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitUntil(() => charcter.IsDie);
        objTextRestart.SetActive(true);
    }
}
