using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f; //putting the f after the 0 typecasts it as float, otherwise it is an int and will not work with the rigidbody, see tranform position note below:
    private float speedY = 0f;
    public Rigidbody2D rb; //need to declare the specific component to modify or play with that component, since this modifies mvmnt, need access to the rigidboy of the game object
// Start is called once before the first execution of Update after the MonoBehaviour is created
    // public SpriteRenderer spriteRenderer;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;

void Start(){

}
// Update is called once per frame
void Update(){
        Movement();
}

void Movement(){
    // Horizontal Movement
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed){
            speedX = -moveSpeed;
            spriteRenderer.sprite = bearleft;
        //     //transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f); //this is a way to flip the sprite without needing to make a new sprite for the left direction, but it can cause issues with colliders, scale, and animations
        //     ////transform local scale normally takes double parameters, but since this is a 2D game, the z axis is not needed, so it can be set to 0.3f or any other value that works for the game. The f after the 0.3 typecasts it as float, otherwise it is a double and will not work with the rigidbody
        }   
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed){
            speedX = moveSpeed;
            spriteRenderer.sprite = bearright;
        }

        else{
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed){
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;
        }

        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;
        }

        else{
            speedY = 0;
        }
        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}



