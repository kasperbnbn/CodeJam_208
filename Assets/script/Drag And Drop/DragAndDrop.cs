using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform correctPosition;
    public float snapDistance = 10f;

    public float Alp = .6f;
    public float Alph = 1;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    //Gets the components
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    //https://docs.unity3d.com/2018.2/Documentation/ScriptReference/EventSystems.IDragHandler.html
    //Method to start the drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = Alp;
        //Block other images, so you can drag over the images.
        canvasGroup.blocksRaycasts = true;
    }

    //Method during the dragging
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    //method for stopping the drag
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = Alph;

        // Calculate the distance between the dropped position and the correct position
        float distance = Vector2.Distance(rectTransform.anchoredPosition, correctPosition.anchoredPosition);

        // If the distance is within the snap distance, snap the image to the correct position

        //https://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition.html
        if (distance <= snapDistance)
        {
            rectTransform.anchoredPosition = correctPosition.anchoredPosition;

            // Check if all images are on the selected position
            int numCorrect = 0;
            foreach (DragAndDrop dnd in FindObjectsOfType<DragAndDrop>())
            {
                if (Vector2.Distance(dnd.rectTransform.anchoredPosition, dnd.correctPosition.anchoredPosition) <= snapDistance)
                {
                    numCorrect++;
                }
            }

            // Switches scene if all images are on their selceted spot.
            if (numCorrect == FindObjectsOfType<DragAndDrop>().Length)
            {
               
                SceneManager.LoadScene(3);
            }
        }

        canvasGroup.blocksRaycasts = true;
    }
}
