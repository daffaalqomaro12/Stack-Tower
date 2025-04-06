using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject block;
    int poolSize = 100;
    [SerializeField] Transform spawnPos;
    [SerializeField] List<GameObject> pool = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 1; i < poolSize; i++){
            GameObject obj = Instantiate(block);
            obj.SetActive(false);
            obj.transform.SetParent(spawnPos);
            pool.Add(obj);
        }
    }

    public GameObject GetBlock(){
        foreach(var obj in pool){
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        GameObject newObj = Instantiate(block);
        pool.Add(newObj);
        return newObj;
    }
    void Update()
    {
        
    }
}
