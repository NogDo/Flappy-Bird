using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIManager : MonoBehaviour
{
    #region ���� ����
    [SerializeField]
    private GameObject objTextRestart;
    [SerializeField, Header("�÷��̾�")]
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
