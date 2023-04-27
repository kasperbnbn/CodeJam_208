using UnityEngine;

public class JigsawPiece : MonoBehaviour
{
    // Reference to the puzzle script
    private JigsawPuzzle jigsawPuzzle;

    // Store the original rotation of the piece
    private Quaternion originalRotation;

    // Flag to indicate if the piece is in the correct position
    private bool isCorrectlyPlaced = false;

    // Initialize the reference to the puzzle script and store the original rotation of the piece
    private void Start()
    {
        Shuffle();

        jigsawPuzzle = transform.parent.GetComponent<JigsawPuzzle>();
        originalRotation = transform.localRotation;
    }

    // Shuffle the puzzle pieces randomly by rotating them
    private void Shuffle()
    {
        Vector3 randomAngle = new Vector3(0f,0f, 90 * Random.Range(1, 4));
        transform.Rotate(randomAngle);
    }

    // Check for left mouse button click to rotate the piece and check if the puzzle is complete
    private void OnMouseDown()
    {
        if (!jigsawPuzzle.puzzleComplete)
        {
            Vector3 Angle = new Vector3(0f, 0f, -90f);
            transform.localRotation *= Quaternion.Euler((Angle));
            jigsawPuzzle.CheckPuzzleComplete();
        }
    }

    // Reset the piece to its original rotation
    public void ResetPiece()
    {
        isCorrectlyPlaced = false;
        transform.localRotation = originalRotation;
    }

    // Set the flag to indicate that the piece is in the correct position
    public void SetCorrectlyPlaced()
    {
        isCorrectlyPlaced = true;
    }

    // Check if the piece is in the correct position
    public bool IsCorrectlyPlaced()
    {
        return isCorrectlyPlaced;
    }
}
