using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPoolManager : MonoBehaviour
{
    #region 전역 변수
    [SerializeField, Header("땅")]
    private CObjectPool groundPool;
    [SerializeField, Header("기둥")]
    private CObjectPool pillarPool;
    [SerializeField]
    private float fPillarSpawnTime;
    [SerializeField, Header("플레이어")]
    private CCharacterMove charcter;

    private IEnumerator spawnGround;
    private IEnumerator spawnPillar;
    private IEnumerator playerDeadCheck;
    private bool isStartSpawn = false;
    #endregion

    void Update()
    {
        if (!isStartSpawn)
        {
            spawnGround = SpawnGround();
            spawnPillar = SpawnPillar();
            playerDeadCheck = PlayerDeadCheck();

            StartCoroutine(spawnGround);
            StartCoroutine(spawnPillar);
            StartCoroutine(playerDeadCheck);

            isStartSpawn = true;
        }
    }

    IEnumerator SpawnGround()
    {
        while (true)
        {
            groundPool.SpawnObject();
            yield return new WaitUntil(() => groundPool.GetNowGameObject().GetComponent<CGroundMove>().IsEnd);
        }
    }

    IEnumerator SpawnPillar()
    {
        while (true)
        {
            pillarPool.SpawnObject();
            yield return new WaitForSeconds(fPillarSpawnTime);
        }
    }

    IEnumerator PlayerDeadCheck()
    {
        yield return new WaitUntil(() => charcter.IsDie);

        StopCoroutine(spawnGround);
        StopCoroutine(spawnPillar);

        for (int i = 0; i < groundPool.GetObjectPool().Count; ++i)
        {
            if (groundPool.GetObjectPool()[i].activeSelf)
            {
                groundPool.GetObjectPool()[i].GetComponent<CGroundMove>().StopMove();
            }
        }

        for (int i = 0; i < pillarPool.GetObjectPool().Count; ++i)
        {
            if (pillarPool.GetObjectPool()[i].activeSelf)
            {
                pillarPool.GetObjectPool()[i].GetComponent<CPillarMove>().StopMove();
            }
        }
    }
}
