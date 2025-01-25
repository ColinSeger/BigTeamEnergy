using UnityEngine;

public class Player2Controll : MonoBehaviour
{
    [SerializeField]float speed;
    float distance = 0.2f;
    void FixedUpdate(){
        var up = Physics2D.Raycast(this.transform.position ,Vector2.up, distance);
        var down = Physics2D.Raycast(this.transform.position ,Vector2.down, distance);
        if(Input.GetKey(KeyCode.UpArrow) && !up){
            this.transform.position += new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        }
        else if(Input.GetKey(KeyCode.DownArrow) && !down){
            this.transform.position -= new Vector3(0, 1, 0) * speed * Time.fixedDeltaTime;
        } 
    }
}
