using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
