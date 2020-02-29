 using UnityEngine;

 
 public class mainBalls : MonoBehaviour {
     public float speed;
     public Collider similarBall;
     public Collider differentBall;
     private Vector3 destination = Vector3.zero;
     public Vector3 initialPos;
     public mainScript gameDelegate;

     void Start () {
         // Set the destination to be the object's position so it will not start off moving
         //SetDestination (gameObject.transform.position);
     }
     
     void Update () {
         // If the object is not at the target destination
         if (destination != gameObject.transform.position) {
             // Move towards the destination each frame until the object reaches it
             IncrementPosition ();
         }
     }
 
     void IncrementPosition ()
     {
         if(destination == Vector3.zero)
         {
             return;
         }
         // Calculate the next position
         float delta = speed * Time.deltaTime;
         Vector3 currentPosition = gameObject.transform.position;
         Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, delta);
 
         // Move the object to the next position
         gameObject.transform.position = nextPosition;
     }
 
     // Set the destination to cause the object to smoothly glide to the specified location
     public void SetDestination (Vector3 value) {
       
         destination = value;
     }

    private void OnTriggerEnter(Collider collider)
    {

        if(collider == similarBall)
        {
            gameDelegate.Win();
        }
        else if(collider == differentBall)
        {
            gameDelegate.Lose();
        }
    }
 }