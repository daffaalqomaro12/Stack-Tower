using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectPool pool;
    [SerializeField] GameObject currentBlock;
    public GameObject lastBlock;
    public Transform spawnPos;
    public Camera camera;
    private Vector3 targetCameraPosition;
    public  float maxZoom = 10f;
    private Vector3 baseSpawnPos;
    public float cameraMoveSpeed = 1f;
    public bool firstBlock = true;
    public float spawnOffset = 0f;
    public int count;
    
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
        if((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.Space)) && currentBlock != null){
            currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            currentBlock.transform.SetParent(null);
            lastBlock = currentBlock;
            currentBlock = null;
            count++;
            Debug.Log("Block ke-" + count);
            firstBlock = false;

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
        Vector2 blockStartPos = new Vector2(spawnPos.position.x, spawnPos.position.y);
        currentBlock.transform.position = blockStartPos;
        currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
