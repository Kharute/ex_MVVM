using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SpawnManager s_manager;
    float speed = 1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        s_manager = GetComponentInParent<SpawnManager>();
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime* speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(nameof(Player)))
        {
            GameObject obj = gameObject;

            GameLogicManager.Inst.RequestHPChange(-20);

            obj.transform.position = s_manager.transform.position;
            obj.SetActive(false);
            s_manager.spawnQueue.Enqueue(obj);
        }
    }
}
