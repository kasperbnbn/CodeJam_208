using UnityEngine;
using UnityEngine.SceneManagement;

public class JigsawPuzzle : MonoBehaviour
{
    // Name of the scene to load when the puzzle is complete
    public string nextSceneName;

    // Flag to indicate if the puzzle is complete
    public bool puzzleComplete = false;

    // Check for touch input to load the next scene once the puzzle is complete
    private void Update()
    {
        if (puzzleComplete && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // Check if all puzzle pieces are correctly placed
    public void CheckPuzzleComplete()
    {
        bool allPiecesCorrectlyPlaced = true;
        foreach (Transform child in transform)
        {
            if (child.localEulerAngles != Vector3.zero)
            {
                // If any puzzle piece is not correctly placed, set the flag to false and exit the loop
                allPiecesCorrectlyPlaced = false;
                break;
            }
        }

        // If all puzzle pieces are correctly placed, set the puzzleComplete flag to true
        if (allPiecesCorrectlyPlaced)
        {
            puzzleComplete = true;

            SceneManager.LoadScene(0);

            Debug.Log("Puzzle complete!");
        }
    }
}