using UnityEngine;

public class PushBubble : MonoBehaviour
{
    enum Direction :byte{
        Left,
        Right
    }
    [SerializeField] float pushForce = 10f;
    [SerializeField] Direction direction = Direction.Left;
    void OnTriggerStay(Collider collision){
        var bubble = collision.gameObject.GetComponent<Rigidbody>();
        if(bubble){
            Debug.Log("This should not");
            bubble.AddForce(this.transform.forward * pushForce * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D collider){
        var bubble = collider.gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("das");
        if(bubble){
            float speed = 2;
            if(direction == Direction.Left){
                speed = -2;
            }
            bubble.AddForce(speed * bubble.transform.right);
            bubble.MoveRotation(Vector2.Angle(collider.transform.position, this.transform.position));
        }
    }
}
