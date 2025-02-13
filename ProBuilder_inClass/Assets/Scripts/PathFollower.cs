using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	//setting speed intially to 0 
    public float speed; 

//add if you want to have different speeds for different parts of your scene
    public float[] speeds; 
	public Transform pathParent;
	Transform targetPoint;
	int index;

//uncomment to see pathway of camera
	// void OnDrawGizmos()
	// {
	// 	Vector3 from;
	// 	Vector3 to;
	// 	for (int a=0; a<pathParent.childCount; a++)
	// 	{
	// 		from = pathParent.GetChild(a).position;
	// 		to = pathParent.GetChild((a+1) % pathParent.childCount).position;
	// 		Gizmos.color = new Color (1, 0, 0);
	// 		Gizmos.DrawLine (from, to);
	// 	}
	// }
	void Start () {
		index = 0;
    
        //sets intial waypoint to first in pathParent GameObject
		targetPoint = pathParent.GetChild (index);    
        speed = speeds[index]; 
	}
	
	// Update is called once per frame
	void Update () {
      if(index < pathParent.childCount){
		transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
		if (Vector3.Distance (transform.position, targetPoint.position) < 0.1f) 
		{
            //stops moving camera if it's at the last waypoint
                index++;
                targetPoint = pathParent.GetChild (index);
                speed = speeds[index-1]; 
            }
		}
	}
}