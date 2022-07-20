using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject pickUp1Prefab;
    [SerializeField]
    private GameObject pickUp2Prefab;
    [SerializeField]
    private int pickUp1Count = 50;
    [SerializeField]
    private int pickUp2Count = 25;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < this.pickUp1Count; i++)
        {
            var position = new Vector3(Random.Range(-15.0f, 15.0f), 0.5f, Random.Range(-15.0f, 15.0f));
            Instantiate(this.pickUp1Prefab, position, Quaternion.identity);
        }

        for (int i = 0; i < this.pickUp2Count; i++)
        {
            var position = new Vector3(Random.Range(-15.0f, 15.0f), 0.5f, Random.Range(-15.0f, 15.0f));
            Instantiate(this.pickUp2Prefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
