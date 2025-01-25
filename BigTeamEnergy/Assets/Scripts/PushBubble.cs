using System.Threading;
using UnityEngine;
public enum Direction :byte{
    Left,
    Right
}
public class PushBubble : MonoBehaviour
{
    
    [SerializeField] AnimationCurve pushForce;
    [SerializeField] Direction direction = Direction.Left;
    [SerializeField] bool barrier;
    [SerializeField] float angleMultiplier = 2f;
    void OnTriggerStay(Collider collision){
        var bubble = collision.gameObject.GetComponent<Rigidbody>();
        if(bubble){
            bubble.AddForce(this.transform.forward * pushForce.Evaluate(Vector3.Angle(collision.gameObject.transform.position, this.transform.position)) * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D collider){
        var bubble = collider.gameObject.GetComponent<Rigidbody2D>();
        if(bubble){
            float speed = 2;
            if(direction == Direction.Left){
                speed = -2;
            }
            
            if(!barrier){
                bubble.AddForce(speed * pushForce.Evaluate(Vector2.Distance(collider.transform.position, this.transform.parent.position)) * bubble.transform.right);
                bubble.MoveRotation(Vector2.Angle(collider.gameObject.transform.position, this.transform.parent.position) * angleMultiplier);                
            }else{
                bubble.AddForce(speed * pushForce.Evaluate(Vector2.Distance(collider.transform.position, this.transform.position)) * bubble.transform.right);
                bubble.MoveRotation(this.transform.rotation);
            }
        }
    }
}
