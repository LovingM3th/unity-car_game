using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject[] obstacles;

    [SerializeField] private float speed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private LayerMask carObstacleLayerMask;
    [SerializeField] private float detectionDistance;

    private float deadZone = -90;

    // Start is called before the first frame update
    void Start()
    {
        //obstacles = GameObject.FindGameObjectsWithTag(tag: "ObstacleCar");
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * speed * Time.deltaTime;

        if(Physics2D.Raycast(transform.position, Vector3.up, detectionDistance, carObstacleLayerMask))
        {
            speed += 0.05f;
        }

        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }

    }

}
