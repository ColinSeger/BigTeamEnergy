using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Image handle;
    [SerializeField] GameObject fan;
    [SerializeField] Camera camera;

    private void Start()
    {
        handle.color = new Color(0, 0, 0, 0);
    }
    private void Update()
    {
        Vector3 screenPosition = RectTransformUtility.WorldToScreenPoint(null, handle.rectTransform.position);
        fan.transform.position = camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, camera.nearClipPlane));

    }
}