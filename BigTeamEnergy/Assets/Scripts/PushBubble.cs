using UnityEngine;

public class PushBubble : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            rigidbody.AddForce(new Vector3(1,0,0));
        }
    }
}
