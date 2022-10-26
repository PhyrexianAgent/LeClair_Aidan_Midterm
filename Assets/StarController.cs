using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] private float persistTime = 4;
    [SerializeField] private float startYSpeed = 5;
    [SerializeField] private float maxXRandSpeed = 5;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity += new Vector2(GetRandXSpeed(), startYSpeed);
        Destroy(gameObject, persistTime);
    }

    private float GetRandXSpeed()
    {
        float randSpeed = Random.Range(0f, maxXRandSpeed);
        int speedMult = Random.Range(0, 2);
        Debug.Log(speedMult);
        return randSpeed * (speedMult == 0 ? 1 : -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
