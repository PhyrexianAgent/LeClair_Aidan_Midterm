using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private const float LERP_SPEED = 0.125f;

    [SerializeField] private float[] minMaxYPos = new float[2];

    private int currentValIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector2(0, minMaxYPos[currentValIndex]), LERP_SPEED);
        if (transform.localPosition.y <= minMaxYPos[0] || transform.localPosition.y >= minMaxYPos[1])
        {
            currentValIndex = currentValIndex == 1 ? 0 : 1;
        }
    }
}
