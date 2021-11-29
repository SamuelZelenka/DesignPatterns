using UnityEngine;
using UnityEngine.UI;

public class ElementSelection : MonoBehaviour
{
    private const float ELEMENT_UI_OFFSET = 15;

    [SerializeField] private Image[] elements;

    private byte selectedElements;

    public void SetElementActiveState(int index, bool setActive)
    {
        float yOffset;
        byte elementToSet = (byte)(1 << index);

        if (!IsElementSelected(index) && setActive)
        {
            yOffset = ELEMENT_UI_OFFSET;
            selectedElements += elementToSet;
        }
        else
        {
            yOffset = IsElementSelected(index) ? -ELEMENT_UI_OFFSET : 0;
            selectedElements -= elementToSet;
        }

        MoveUIElementOnYAxis(index, yOffset);
    }

    private bool IsElementSelected(int index)
    {
        byte element = (byte)(selectedElements & (1 << index));
        byte compareElement = (byte)(1 << index);

        return element == compareElement;
    }
    public void DeselectAll()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            if (IsElementSelected(i))
            {
                MoveUIElementOnYAxis(i, -ELEMENT_UI_OFFSET);
            } 
        }
        selectedElements = 0;
    }
    private void MoveUIElementOnYAxis(int index, float yOffset)
    {
        elements[index].transform.position += new Vector3(0, yOffset, 0);
    }
}
