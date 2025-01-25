using System.Threading;
using UnityEngine;
public enum Direction :byte{
    Left,
    Right
}
public class PushBubble : MonoBehaviour
{
    
    [SerializeField] float pushForce = 10f;
    [SerializeField] Direction direction = Direction.Left;
    [SerializeField] bool barrier;
    [SerializeField] float angleMultiplier = 2f;
    void OnTriggerStay(Collider collision){
        var bubble = collision.gameObject.GetComponent<Rigidbody>();
        if(bubble){
            bubble.AddForce(this.transform.forward * pushForce * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D collider){
        var bubble = collider.gameObject.GetComponent<Rigidbody2D>();
        if(bubble){
            float speed = 2;
            if(direction == Direction.Left){
                speed = -2;
            }
            bubble.AddForce(speed * pushForce * bubble.transform.right);
            if(!barrier){
                bubble.MoveRotation(Vector2.Angle(collider.gameObject.transform.position, this.transform.position) * angleMultiplier);                
            }else{
                bubble.MoveRotation(this.transform.rotation);
            }
        }
    }
}
