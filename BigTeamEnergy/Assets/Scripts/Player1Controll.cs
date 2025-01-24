using UnityEngine;

public class Player1Controll : MonoBehaviour
{
    [SerializeField]float speed;
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.W)){
            this.transform.position += new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        }
        else if(Input.GetKey(KeyCode.S)){
            this.transform.position -= new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        } 
    }
}
