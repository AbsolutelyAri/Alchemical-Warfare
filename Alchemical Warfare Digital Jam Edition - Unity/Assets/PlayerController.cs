using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animation anim;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

private void Start() {
    rb = gameObject.GetComponent<Rigidbody>();
    anim = gameObject.GetComponent<Animation>();
    moveSpeed =3f;
    jumpForce = 60f;
    isJumping = false;

}
    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

    }
  
  private void FixedUpdate() {
    if(moveHorizontal > .1f || moveHorizontal <.1f){
        rb.AddForce(new Vector2(moveHorizontal *  Time.deltaTime * moveSpeed, 0f), ForceMode.Impulse);
        anim.Play("BattleRunForward");
    }
     if(moveVertical > .1f || moveVertical <.1f){
        rb.AddForce(new Vector2(moveVertical *moveSpeed, 0f), ForceMode.Impulse);
    }
  }
}
