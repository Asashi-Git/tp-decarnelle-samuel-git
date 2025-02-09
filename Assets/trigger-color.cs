using UnityEngine;
using System.Collections.Generic;

public class TagColorChanger : MonoBehaviour
{
    // Tags for identifying objects to change color
    public string targetTag1 = "ChangeColor"; // First tag
    public string targetTag2 = "ChangeColor2"; // Second tag

    // Colors to apply when player enters the trigger
    public Color enterColor1 = Color.red; // Color for first tag when the player is inside the trigger
    public Color enterColor2 = Color.blue; // Color for second tag when the player is inside the trigger

    // Dictionary to store original colors of objects before they change
    private Dictionary<GameObject, Color> originalColors = new Dictionary<GameObject, Color>();

    // Flag to track if the player is inside the trigger
    private bool playerInside = false;

    private void Start()
    {
        // Store original colors of all objects with both target tags
        StoreOriginalColors(targetTag1);
        StoreOriginalColors(targetTag2);
    }

    // Store the original colors of all objects with the specified tag
    private void StoreOriginalColors(string tag)
    {
        GameObject[] objectsToChange = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToChange)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();
            if (objRenderer != null && !originalColors.ContainsKey(obj))
            {
                originalColors[obj] = objRenderer.material.color; // Save original color
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only react if the player enters the trigger
        if (other.CompareTag("Player"))
        {
            playerInside = true; // Set flag
            UpdateColors(); // Change object colors
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Only react if the player exits the trigger
        if (other.CompareTag("Player"))
        {
            playerInside = false; // Reset flag
            UpdateColors(); // Restore original colors
        }
    }

    // Update the colors of objects based on whether the player is inside the trigger
    private void UpdateColors()
    {
        ChangeObjectColors(targetTag1, enterColor1);
        ChangeObjectColors(targetTag2, enterColor2);
    }

    // Change the colors of objects with the specified tag
    private void ChangeObjectColors(string tag, Color enterColor)
    {
        GameObject[] objectsToChange = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToChange)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();
            if (objRenderer != null && originalColors.ContainsKey(obj))
            {
                // If player is inside, change to enterColor; otherwise, revert to original color
                objRenderer.material.color = playerInside ? enterColor : originalColors[obj];
            }
        }
    }
}