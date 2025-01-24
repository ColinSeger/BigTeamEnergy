using UnityEngine;

public class Player2Controll : MonoBehaviour
{
    [SerializeField]float speed;
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.UpArrow)){
            this.transform.position += new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            this.transform.position -= new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        } 
    }
}
