using UnityEngine;
using TMPro;
using System.Collections;

public class PointsPopUp : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] TextMeshPro tmPro;
    float startTime;
    float targetYPos;
    private void Start()
    {
        StartCoroutine(kill());

        targetYPos = rect.position.y + 1f;
    }
    private void Update()
    {
        if (startTime < 2)
        {
            startTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, startTime/2);
            float yPos = Mathf.Lerp(rect.position.y, targetYPos, startTime/2);
            tmPro.color = new Color(tmPro.color.r, tmPro.color.g, tmPro.color.b, alpha);
            rect.position = new Vector2(rect.position.x,yPos);
        }


    }
    IEnumerator kill()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
