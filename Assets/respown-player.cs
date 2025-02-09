using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name); // Debug message

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the cube! Restarting scene...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
