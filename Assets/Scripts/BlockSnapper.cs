using System.Collections;
using UnityEngine;


public class BlockSnapper : MonoBehaviour
{
    [SerializeField] ObjectSpawner objectSpawner;


    void Start()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }
    void LockBlock(){

        if(objectSpawner.lastBlock != null){
            StartCoroutine(FixRotate(objectSpawner.lastBlock.transform));
            objectSpawner.lastBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("LockBlock", 1f);
    }

    IEnumerator FixRotate(Transform block){
        Quaternion currentRot = block.rotation;
        Quaternion targetRot = Quaternion.Euler(0, 0, 0);
        float time = 0f;
        float duration = 0.3f;

        while(time < duration){
            block.rotation = Quaternion.Lerp(currentRot, targetRot, time/duration);
            time += Time.deltaTime;
            yield return null;
        }

        block.rotation = targetRot;
    }
}
