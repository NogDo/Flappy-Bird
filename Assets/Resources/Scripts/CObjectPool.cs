using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectPool : MonoBehaviour
{
    #region 전역 변수
    private List<GameObject> objectPool;
    private int nPointer;

    [SerializeField]
    private GameObject objPooled;
    [SerializeField]
    private int nObjectCount;
    private int nNowIndex = 0;
    #endregion

    void Start()
    {
        nPointer = 0;
        objectPool = new List<GameObject>();

        for (int i = 0; i < nObjectCount; i++)
        {
            objPooled = Instantiate(objPooled, Vector3.zero, Quaternion.identity);
            objPooled.SetActive(false);
            objPooled.transform.parent = transform;

            objectPool.Add(objPooled);
        }
    }

    public void SpawnObject()
    {
        if (nPointer != objectPool.Count)
        {
            objectPool[nPointer].SetActive(true);
            nPointer++;
        }

        else
        {
            nPointer = 0;
            objectPool[nPointer].SetActive(true);
            nPointer++;
        }

        nNowIndex++;
        if (nNowIndex > 2)
        {
            nNowIndex = 0;
        }
    }

    public GameObject GetNowGameObject()
    {
        return objectPool[nNowIndex];
    }
}
