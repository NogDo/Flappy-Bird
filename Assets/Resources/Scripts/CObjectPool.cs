using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CObjectPool : MonoBehaviour
{
    #region 전역 변수
    private List<GameObject> objectPool;
    private int nPointer;
    private int nNowIndex = -1;

    [SerializeField]
    private GameObject objPooled;
    [SerializeField]
    private int nObjectCount;
    #endregion

    void Start()
    {
        nPointer = 0;
        objectPool = new List<GameObject>();

        for (int i = 0; i < nObjectCount; i++)
        {
            GameObject obj = Instantiate(objPooled, Vector3.zero, Quaternion.identity);
            obj.SetActive(false);
            obj.transform.SetParent(transform);

            objectPool.Add(obj);
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
        if (nNowIndex >= nObjectCount)
        {
            nNowIndex = 0;
        }
    }

    public GameObject GetNowGameObject()
    {
        return objectPool[nNowIndex];
    }

    public List<GameObject> GetObjectPool()
    {
        return objectPool;
    }
}
