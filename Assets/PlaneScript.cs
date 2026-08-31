
using DG.Tweening;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.DOMoveX(100, 20).SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
