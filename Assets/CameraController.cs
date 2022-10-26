using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTrans;

    private const float LERP_SPEED = 0.125f;

    [SerializeField] private float xZoneWidth = 5;
    [SerializeField] private float[] minMaxXPos = new float[2];
    //[SerializeField] private Vector2 zonePos = new Vector2(0, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 targetPos = playerTrans.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, LERP_SPEED) + new Vector3(0, 0, -3);
        
    }
}
