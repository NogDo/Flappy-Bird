using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPoolManager : MonoBehaviour
{
    #region 전역 변수
    [SerializeField]
    private CObjectPool groundPool;
    [SerializeField]
    private CObjectPool pillarPool;

    private bool isStartSpawn = false;
    #endregion

    void Update()
    {
        if (!isStartSpawn)
        {
            StartCoroutine(SpawnGround());

            isStartSpawn = true;
        }
    }

    IEnumerator SpawnGround()
    {
        while (true)
        {
            groundPool.SpawnObject();

            yield return new WaitUntil(() => groundPool.GetNowGameObject().GetComponent<CGroundMove>().IsMiddle);
        }
    }

    IEnumerator SpawnPillar()
    {
        while (true)
        {
            pillarPool.SpawnObject();


        }
    }
}
