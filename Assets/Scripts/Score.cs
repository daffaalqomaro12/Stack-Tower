using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private ObjectSpawner objectSpawner;
    [SerializeField] TMP_Text scoreText;
    private int count;


    void Start()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();
    }

    void Update()
    {
        count = objectSpawner.count;
        scoreText.text = "Score: " + count;
    }
}
