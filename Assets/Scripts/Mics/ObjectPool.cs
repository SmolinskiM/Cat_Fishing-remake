using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    public Action OnRealeaseObject;

    private T objectPrefab;
    private List<T> objectList = new List<T>();
    private Transform mainObject;

    public ObjectPool(T objectPrefab, Transform mainObject)
    { 
        this.objectPrefab = objectPrefab;
        this.mainObject = mainObject;
    }

    public T OnTake()
    {
        if(objectList.Count == 0) 
        {
            CreateObject();
        }

        foreach(T _object in objectList)
        {
            if(_object.gameObject.activeSelf == false)
            {
                _object.gameObject.SetActive(true);
                return _object;
            }
        }

        return CreateObject();
    }

    public void OnRealease(T _object)
    {
        _object.gameObject.SetActive(false);
        Debug.Log("xd");
        OnRealeaseObject?.Invoke();
    }

    private T CreateObject()
    {
        T _object = Instantiate(objectPrefab, mainObject.position, Quaternion.identity);
        objectList.Add(_object);
        return _object;
    }
}
