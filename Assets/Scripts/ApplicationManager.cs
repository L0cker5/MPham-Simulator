using UnityEngine;

/// <summary>
/// Attached to the Quit Game button in the start menu UI 
/// </summary>
public class ApplicationManager : MonoBehaviour
{
    // Quits the application back to the home page of the quest
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

}
