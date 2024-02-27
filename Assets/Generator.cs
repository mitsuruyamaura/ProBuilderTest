using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float interval = 3.0f;
    [SerializeField] private int maxGenerateCount = 10;

    private float timer;
    private int generateCount;


    void Update()
    {
        if (generateCount <= maxGenerateCount) {
            return;
        } 

        timer += Time.deltaTime;
        
        if(timer >= interval) {
            timer = 0;
            generateCount++;
            Instantiate(prefab, transform);
        }
    }
}