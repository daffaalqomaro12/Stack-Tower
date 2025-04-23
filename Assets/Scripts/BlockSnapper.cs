using System.Collections;
using UnityEngine;


public class BlockSnapper : MonoBehaviour
{
    private ObjectSpawner objectSpawner;


    void Start()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }
    void LockBlock(){

        if(objectSpawner.lastBlock != null){
            StartCoroutine(FixRotate(objectSpawner.lastBlock.transform));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("LockBlock", 0.3f);
    }

    IEnumerator FixRotate(Transform block){
        Quaternion currentRot = block.rotation;
        Quaternion targetRot = Quaternion.Euler(0, 0, 0);
        float time = 0f;
        float duration = 0.5f;

        while(time < duration){
            block.rotation = Quaternion.Lerp(currentRot, targetRot, time/duration);
            time += Time.deltaTime;
            yield return null;
        }

        block.rotation = targetRot;
        block.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        objectSpawner.lastBlock.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
