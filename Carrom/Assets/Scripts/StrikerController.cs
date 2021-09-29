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
	private Transform StrikerBG;
	
	private bool StrikerForce;
	
	RaycastHit2D hit;
	
	private Rigidbody2D RB;
	
	[SerializeField]
	private Transform ForcePoint;
	
	private float force = 50.0f;
	
	private Vector2 startPos;
	public int pixelDistanceToDetect = 50;
	private float sensitivity = 10f;
	private float movement = 0f;
	public float moveSpeed = 600f;
	
	void Start()
	{
		StrikerSlider.onValueChanged.AddListener(StrikerXPosition);
		RB = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
			startPos = Input.mousePosition;
			
			if(hit.collider)
			{
				if(hit.transform.name == "Striker")
			    {
				StrikerForce = true;
					
			    }
				
			   if(StrikerForce)
			    {
				//StrikerBG.LookAt(hit.point);
		          if(Input.mousePosition.x <= startPos.x - pixelDistanceToDetect)    
			      {
				    Debug.Log("Swipe left");
				    movement = sensitivity;
					StrikerForce = false;
				
			      }
			      else if(Input.mousePosition.x >= startPos.x + pixelDistanceToDetect) 
			      {
				    Debug.Log("Swipe Right");
				     movement = -sensitivity;
					  StrikerForce = false;
			      }
			    }
				
				float ScaleValue = Vector2.Distance(transform.position, hit.point);
				StrikerBG.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
				
				Debug.Log(hit.transform.name);
			}
			
		}
		 
		
	}
	
	private void FixedUpdate()                                                 //-- rotate the player around the center ---//
	{
		StrikerBG.transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
		
		if(Input.GetMouseButtonUp(0))
		{
			RB.AddForce(ForcePoint.position * force);
		}
		
	}
	
    void StrikerXPosition(float Value)
    {
	  transform.position = new Vector3(Value, -1.57f, 0);
    }
} 
