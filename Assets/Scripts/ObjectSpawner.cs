using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectPool pool;
    private GameObject currentBlock;
    public Transform spawnPos;
    public Camera camera;
    private Vector3 targetCameraPosition;
    public  float maxZoom = 10f;
    public float cameraMoveSpeed = 1f;

    private int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetCameraPosition = camera.transform.position;
        SpawnBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
        camera.transform.position = Vector3.Lerp(camera.transform.position, targetCameraPosition, Time.deltaTime * cameraMoveSpeed);
        if(Input.GetMouseButtonDown(0) && currentBlock != null){
            currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            currentBlock = null;
            count++;

            targetCameraPosition.y += 3f;
            if (Camera.main.orthographicSize < maxZoom)
            {
                Camera.main.orthographicSize += 50 * Time.deltaTime;
            }else{
                targetCameraPosition.y -= 0.2f;
            }

            Invoke("SpawnBlock", 0.5f);
        }
    }

    void SpawnBlock(){
        currentBlock = pool.GetBlock();
        currentBlock.SetActive(true);
        float spawnY = camera.transform.position.y + camera.orthographicSize - 1f;
        Vector2 blockStartPos = new Vector2(0f, spawnY);
        currentBlock.transform.position = blockStartPos;
        Vector3 viewPos = Camera.main.WorldToViewportPoint(currentBlock.transform.position);
        

        currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
