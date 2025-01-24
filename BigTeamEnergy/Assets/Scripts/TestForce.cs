using UnityEngine;

public class TestForce : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.AddForce(Vector2.right * 10,ForceMode2D.Impulse);
        }
    }
}
