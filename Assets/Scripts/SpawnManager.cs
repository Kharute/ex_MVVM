using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance = null;

    [SerializeField]
    GameObject Bullet_Prefab;

    float Cooltime = 3f;
    float time = 0f;
    
    public Queue<GameObject> spawnQueue = new Queue<GameObject>();
    int queueCount = 5;
    
    public static SpawnManager Inst
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SpawnManager();
                
            }
            return _instance;
        }
    }

    private void Awake()
    {
        InitQueue();
        time = Cooltime;
    }

    private void Update()
    {
        time -= Time.deltaTime;

        if (time < 0f)
        {
            Dequeues();
            
            time = Cooltime;
        }
    }

    private void InitQueue()
    {
        for (int i = 0; i < queueCount; i++)
        {
            GameObject bullet = Instantiate(Bullet_Prefab, transform);
            bullet.SetActive(false);
            spawnQueue.Enqueue(bullet);
        }
    }
    void Dequeues()
    {
        GameObject obj = spawnQueue.Dequeue();
        obj.SetActive(true);
    }


}
