using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Sprite openTexture;
    public GameObject starPrefab;
    public LayerMask playerLayer;

    private const KeyCode KEY_TO_USE = KeyCode.E;

    [SerializeField] private float starSpawnTimeMax = 0.4f;

    private bool ableToBeOpened = false;
    private bool isOpened = false;
    private float starSpawnTimer = 0;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TestForKey();
        if (isOpened)
        {
            SpawnStars();
        }
    }

    private void SpawnStars()
    {
        starSpawnTimer -= Time.deltaTime;
        if (starSpawnTimer <= 0)
        {
            Instantiate(starPrefab, transform.position, Quaternion.identity);
            starSpawnTimer = starSpawnTimeMax;
        }
    }

    private void TestForKey()
    {
        if (ableToBeOpened && Input.GetKeyDown(KEY_TO_USE))
        {
            isOpened = true;
            GetComponent<SpriteRenderer>().sprite = openTexture;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ableToBeOpened = GetComponent<BoxCollider2D>().IsTouchingLayers(playerLayer);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ableToBeOpened = false;
    }
}
