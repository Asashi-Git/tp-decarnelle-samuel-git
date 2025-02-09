using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnimator;
    private bool isNear = false;

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E)) // "E" pour activer
        {
            doorAnimator.SetTrigger("Open");
            Debug.Log("You Win");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
        }
    }
}