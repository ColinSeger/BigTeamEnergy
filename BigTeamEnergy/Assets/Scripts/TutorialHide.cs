using System.Collections;
using UnityEngine;

public class TutorialHide : MonoBehaviour
{
    [SerializeField] GameObject tut;
    void Start()
    {
        StartCoroutine(HideTut());
    }
    IEnumerator HideTut(){
        yield return new WaitForSeconds(2f);
        tut.SetActive(false);
    }
}
