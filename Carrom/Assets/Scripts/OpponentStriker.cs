using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentStriker : MonoBehaviour
{
    [SerializeField]
	private Slider StrikerSlider;
	
	[SerializeField]
	private LineRenderer Line;
	
	RaycastHit2D hit;
	
	private Rigidbody2D RB;
	
	[SerializeField]
	private Transform ForceCircle;
	[SerializeField]
	private GameObject Arrow;
	[SerializeField]
	private GameObject StrikerGlow;
	
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
	[SerializeField]
	private GameObject GameManager;
	
	public AudioSource Swipe;

	
	void Start()
	{
	                                
		StrikerSlider.onValueChanged.AddListener(StrikerXPosition);  //--If the slider is move, the slider value given to method-//
		RB = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
        startPos = transform.position;                                          //--Get the initial position of striker--//
		Line.enabled = false;
		Arrow.SetActive(false);
		
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);                 //--Get the mouse position--//
		
		mousePosition.x = Mathf.Clamp(mousePosition.x, -2.0f, 2.0f);     //--Clamp the value to mouse position in between (-2,2)--//
		mousePosition.y = Mathf.Clamp(mousePosition.y, -2.0f, 2.0f);
		mousePosition.z = Mathf.Clamp(mousePosition.z, -2.0f, 2.0f);
		
		mousePosition2 = new Vector3(-mousePosition.x, -mousePosition.y, mousePosition.z);   //--Set the touch point according to                                                                                             mouse position--/
		                                   
			
		if(isOverlap)                                             //--If the token overlaps with striker when striker is not set--// 
		{
			Line.enabled = false;                                 //--Line is disabled--//
			isStrikerSet = false;                                 //--Can move the striker to set but can't hit if overlap--//
		}
		
		if(Input.GetMouseButtonUp(0) && RB.velocity.magnitude == 0 && isStrikerSet && !isOverlap) 
		{
			Swipe.Play();
			StrikerShoot();   //--If MouseButtonUp i.e released & stiker is not moving & strikerSet through slider & not Overlap--//
		}
		
		hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); 
		if(hit.collider != null)          //--Raycast from camera position to mousePosition if it hit striker i.e touched striker-//
		{
			if(Input.GetMouseButtonDown(0))  //---If we touch the slider and set it to desired point and release the striker is set
		    {
			  if(!isStrikerSet)
			  {
				isStrikerSet = true;
			  }
		    }
		}
			
		
		
		if(isStrikerSet && RB.velocity.magnitude == 0)   //---If striker is Set and it is not moving get the line renderer--//
		{
			Arrow.SetActive(true);  
			
			Line.enabled = true;
			Line.SetPosition(0, transform.position);     //---Initial position on line i.e start point--//
		    Line.SetPosition(1, mousePosition2);         //---End point--//
			
			float angle = AngleBetweenTwoPoints(Arrow.transform.position, mousePosition2); //-Get the angle between arrow & mousePos
			Arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle + 90); //--Assign the rotation to arrow according to direction
			
		}
		
		if(RB.velocity.magnitude < 0.2f && RB.velocity.magnitude != 0 && isStrikerSet) //--If the striker velocity between 0.2 to 0
		{                                                                              //       reset the striker to initial pos--//
			StrikerReset();
			GameManager.GetComponent<GameManager>().counter++;
		}
		
		if(!hasStriked)                                     //---Striker glow set active to false after we hit--//
		{
			float powerScale; 
			
			StrikerGlow.SetActive(true);
			if((mousePosition.x <= -0.5f || mousePosition.x >= 0.5f))
			{
				powerScale = -mousePosition.x; 
				ForceCircle.transform.localScale = new Vector3(Mathf.Abs(powerScale), Mathf.Abs(powerScale), 0); 
			}
			
			else
			{
				powerScale = -mousePosition.y; 
				ForceCircle.transform.localScale = new Vector3(Mathf.Abs(powerScale), Mathf.Abs(powerScale), 0); 
			}
			
			if((mousePosition.x == 2.0f || mousePosition.x == -2.0f) || (mousePosition.y == 2.0f || mousePosition.y == -2.0f))
			{
				ForceCircle.transform.localScale = new Vector3(2,2,0);
			}
			 
		}                                                                                                   
		else
		{
			StrikerGlow.SetActive(false);
			ForceCircle.transform.localScale = new Vector3(0,0,0);            //--disapear the power circle after hitting--//
		}
		
		
	}
	
	void StrikerShoot()                                                  //--If the striker is Set in desired direction--//
	{
		float x = 0;
		if(isStrikerSet && RB.velocity.magnitude == 0)                  
		{
			x = Vector2.Distance(transform.position, -mousePosition); //--Get the distance value between touch point and striker--//
		}
		direction = mousePosition2 - transform.position;                  //---Get the point and direction---//
		direction.Normalize();
		RB.AddForce(direction * x * 300);                       //---Add force to rigidbody in desired direction and force - 300--//
		hasStriked = true;                                      //---After hiting the striker--//
		
	}
	
    void StrikerXPosition(float Value)
    {
	 
		if(!hasStriked && !isStrikerSet)                            //--Initial position not set and not hit--//
		{
			transform.position = new Vector3(Value, 1.57f, 0);     //--move the striker gameobject according to slider value--//
	  
         }
	}
	
	void StrikerReset()                                            //--Set the striker to initial position--//
	{
	    transform.position = new Vector3(0, 1.57f, 0);                              //--Striker to Start position--//
		RB.velocity = Vector2.zero;                                //--Stop moving the striker--//
		hasStriked = false;                                         //--has striker = false for hitting again--//
		isStrikerSet = false;
		Line.enabled = true;                                         
	}
	
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)                   //---Function to get the angle between two points---//
	{
		return Mathf.Atan2(a.y - b.y, a.x -b.x) * Mathf.Rad2Deg;
	}
	

}
