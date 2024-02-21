using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 4f;
	private string new_direction = "";
	public string direction = "";


	private Rigidbody2D rb;
	private float[] stoppingPointsX;
	private int currentLane = 3;


	[SerializeField] private GameObject Node_1;
    [SerializeField] private GameObject Node_2;
    [SerializeField] private GameObject Node_3;
    [SerializeField] private GameObject Node_4;
    [SerializeField] private GameObject Node_5;



	// Start is called before the first frame update
	void Start()
	{

		rb = GetComponent<Rigidbody2D>();

	}


	// Update is called once per frame
	void Update()
	{


		// Adjust for wished lane
		if (GetDirection() == "right")
		{
			currentLane += 1;
		}
		if (GetDirection() == "left")
		{
			currentLane -= 1;
		}



		// Move car to wished lane
		if (currentLane == 1)
		{
			transform.position = Vector2.MoveTowards(transform.position, Node_1.transform.position, speed * Time.deltaTime);
		}
		else if (currentLane == 2)
		{
			transform.position = Vector2.MoveTowards(transform.position, Node_2.transform.position, speed * Time.deltaTime);
		}
		else if (currentLane == 3)
		{
			transform.position = Vector2.MoveTowards(transform.position, Node_3.transform.position, speed * Time.deltaTime);
		}
		else if (currentLane == 4)
		{
			transform.position = Vector2.MoveTowards(transform.position, Node_4.transform.position, speed * Time.deltaTime);
		}
		else if (currentLane == 5)
		{
			transform.position = Vector2.MoveTowards(transform.position, Node_5.transform.position, speed * Time.deltaTime);
		}

		// If-statements to keep "currentLane" in bounds
		if (currentLane > 5)
		{
			currentLane = 5;
		}
		else if (currentLane < 1)
		{
			currentLane = 1;
		}






	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
		Debug.Log("Collided");
    }

    private string GetDirection()
	{
		if (Input.GetKeyDown("d"))
		{
			new_direction = "right";

			return new_direction;

		}
		if (Input.GetKeyDown("a"))
		{
			new_direction = "left";
			return new_direction;
		}
		else
		{
			return direction;
		}
	}
}
