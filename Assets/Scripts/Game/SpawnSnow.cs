using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnow : MonoBehaviour
{
    private float SpawnTime;
    public float Cooldown;
    public GameObject SpawnObject;

    private void FixedUpdate() 
    {
        if(SpawnTime <= Time.time)
        {
            SpawnObject.transform.position = new Vector3(Random.Range(-300, 300), 0, 0);
            GameObject Snow = SpawnObject.gameObject;
            Instantiate(Snow, transform);
            SpawnTime = Time.time + Cooldown;
        }
    }
}
