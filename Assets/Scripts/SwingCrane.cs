using UnityEngine;

public class SwingCrane : MonoBehaviour
{
    [SerializeField] private float force = 2f;
    [SerializeField] private float angle = 20f;

    private float currentAngle = 0;
    float timer;
    public ObjectSpawner objectSpawner;

    void Update()
    {
        if(objectSpawner.firstBlock == false){
            timer += Time.deltaTime;
            float angle = Mathf.Sin(timer) * this.angle;
            transform.rotation = Quaternion.Euler(0, 0, angle + currentAngle);
        }
    }
}
