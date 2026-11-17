using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f; //putting the f after the 0 typecasts it as float, otherwise it is an int and will not work with the rigidbody, see tranform position note below:
    private float speedY = 0f;
    public Rigidbody2D rb; //need to declare the specific component to modify or play with that component, since this modifies mvmnt, need access to the rigidboy of the game object
// Start is called once before the first execution of Update after the MonoBehaviour is created

void Start(){

}
// Update is called once per frame
void Update(){
        Movement();
}

void Movement(){
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}



