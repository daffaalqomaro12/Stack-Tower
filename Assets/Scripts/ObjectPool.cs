using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject block;
    int poolSize = 10;
    [SerializeField] List<GameObject> pool = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < poolSize; i++){
            GameObject obj = Instantiate(block);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetBlock(){
        foreach(var obj in pool){
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(block);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }
    void Update()
    {
        
    }
}
