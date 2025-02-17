using UnityEngine;
using System.Collections;

public class PathFollower_singleSpeed : MonoBehaviour {

	//setting speed intially to 0 
    public float speed = 0.0f; 

	public Transform pathParent;
	Transform targetPoint;
	int index;

//uncomment to see pathway of camera
	void OnDrawGizmos()
	{
		Vector3 from;
		Vector3 to;
		for (int a=0; a<pathParent.childCount; a++)
		{
			from = pathParent.GetChild(a).position;
			to = pathParent.GetChild((a+1) % pathParent.childCount).position;
			Gizmos.color = new Color (1, 0, 0);
            if(a< (pathParent.childCount - 1)){
			    Gizmos.DrawLine (from, to);
            }
		}
	}
	void Start () {
		index = 0;
    
        //sets intial camera position to first in waypoint in our pathParent GameObject
		targetPoint = pathParent.GetChild (index);    
        transform.position = targetPoint.position; 
	}
	
	// Update is called once per frame
	void Update () {
		//ensures index is within bounds of our path 
      	if(index < pathParent.childCount){
			//moves camera towards the next target point 
			transform.position = Vector3.MoveTowards (transform.position, targetPoint.position, speed * Time.deltaTime);
			
			if (Vector3.Distance (transform.position, targetPoint.position) < 0.1f) {
				//stops moving camera if it's at the last waypoint
				index++;

				//camera has reached the end of the path, set it's position to the last waypoint 
                if (index < pathParent.childCount) {
                    targetPoint = pathParent.GetChild(index);
                }
            }
		}
	}
}
