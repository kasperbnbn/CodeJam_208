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

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = Alp;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = Alph;

        // Calculate the distance between the dropped position and the correct position
        float distance = Vector2.Distance(rectTransform.anchoredPosition, correctPosition.anchoredPosition);

        // If the distance is within the snap distance, snap the image to the correct position
        if (distance <= snapDistance)
        {
            rectTransform.anchoredPosition = correctPosition.anchoredPosition;

            // Check if all images are in their correct position
            int numCorrect = 0;
            foreach (DragAndDrop dnd in FindObjectsOfType<DragAndDrop>())
            {
                if (Vector2.Distance(dnd.rectTransform.anchoredPosition, dnd.correctPosition.anchoredPosition) <= snapDistance)
                {
                    numCorrect++;
                }
            }

            // If all images are in their correct position, switch the scene
            if (numCorrect == FindObjectsOfType<DragAndDrop>().Length)
            {
               
                SceneManager.LoadScene(3);
            }
        }

        canvasGroup.blocksRaycasts = true;
    }
}
