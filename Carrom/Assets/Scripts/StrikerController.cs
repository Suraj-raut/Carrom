using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerController : MonoBehaviour
{
	//private const string STRIKER_TAG = "Striker";
	
	[SerializeField]
	private Slider StrikerSlider;
	
	[SerializeField]
	private LineRenderer Line;
	
	RaycastHit2D hit;
	
	private Rigidbody2D RB;
	
	[SerializeField]
	private Transform ForcePoint;
	
	private float force = 50.0f;
	private Vector2 direction;
	private Vector3 mousePosition;
	private Vector3 mousePosition2;
	
	private bool hasStriked = false;
	public bool isOverlap;
	
	
	private bool isStrikerSet = false;
	public bool ISStrikerSet
	{
		get{ return isStrikerSet; }
		set{ isStrikerSet = value; }
	}
	
	private Vector3 startPos;
	//public GameObject StartCollider;
	
	

	void Start()
	{
		//isOverlap = StartCollider.GetComponent<StartCollider>().overlap;
		
		startPos = transform.position;
		StrikerSlider.onValueChanged.AddListener(StrikerXPosition);
		RB = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{

		Line.enabled = false;
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition2 = new Vector3(-mousePosition.x, -mousePosition.y, mousePosition.z);
		
		if(isOverlap)
		{
			Line.enabled = false;
			isStrikerSet = false;
		}
		
		if(Input.GetMouseButtonUp(0) && RB.velocity.magnitude == 0 && isStrikerSet && !isOverlap)
		{
			StrikerShoot();
		}
		
		hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if(hit.collider != null)
		{
			if(Input.GetMouseButtonDown(0))
		    {
			  if(!isStrikerSet)
			  {
				isStrikerSet = true;
			  }
		    }
		}
			
		
		
		if(isStrikerSet && RB.velocity.magnitude == 0)
		{
			Line.enabled = true;
			Line.SetPosition(0, transform.position);
		    Line.SetPosition(1, mousePosition2);
		}
		
		if(RB.velocity.magnitude < 0.2f && RB.velocity.magnitude != 0 && isStrikerSet)
		{
			StrikerReset();
		}
		
		if(mousePosition2.x < -2.34f)
		{
			mousePosition2.y = -2.34f;
		}
		if(mousePosition2.x > 2.34f)
		{
			mousePosition2.x = 2.34f;
		}
		if(mousePosition2.y < -2.34f)
		{
			mousePosition2.y = -2.34f;
		}
		if(mousePosition2.y > 2.34f)
		{
			mousePosition2.y = 2.34f;
		}
		
		
		
	}
	
	void StrikerShoot()
	{
		float x = 0;
		if(isStrikerSet && RB.velocity.magnitude == 0)
		{
			x = Vector2.Distance(transform.position, mousePosition);
		}
		direction = mousePosition2 - transform.position;
		direction.Normalize();
		RB.AddForce(direction * x * 300);
		hasStriked = true;
		
	}
	
    void StrikerXPosition(float Value)
    {
	 
		if(!hasStriked && !isStrikerSet)
		{
			transform.position = new Vector3(Value, -1.57f, 0);
	  
         }
	}
	
	void StrikerReset()
	{
		RB.velocity = Vector2.zero;
	    transform.position = startPos;
		hasStriked = false;
		isStrikerSet = false;
		Line.enabled = true;
	}
	

} 
