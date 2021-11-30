using UnityEngine;
using UnityEngine.UI;

public class ElementSelection : MonoBehaviour
{
    private const float ELEMENT_UI_OFFSET = 15;

    [SerializeField] private Image[] _elements;

    private byte _selectedElements;

    public byte SelectedElements => _selectedElements;

    private void Start()
    {
        int childIndex = 0;
        _elements = new Image[transform.childCount];

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Image imageComponent))
            {
                _elements[childIndex] = imageComponent;
            }
            else
            {
                Debug.LogWarning($"child '{child.name}' is not of type Image.");
            }
            childIndex++;
        }
    }

    public void SetElementActiveState(int index, bool setActive)
    {
        float yOffset;
        byte elementToSet = (byte)(1 << index);

        if (!IsElementSelected(index) && setActive)
        {
            yOffset = ELEMENT_UI_OFFSET;
            _selectedElements += elementToSet;
        }
        else
        {
            yOffset = IsElementSelected(index) ? -ELEMENT_UI_OFFSET : 0;
            _selectedElements -= elementToSet;
        }

        MoveUIElementOnYAxis(index, yOffset);
    }

    private bool IsElementSelected(int index)
    {
        byte element = (byte)(_selectedElements & (1 << index));
        byte compareElement = (byte)(1 << index);

        return element == compareElement;
    }
    public void DeselectAll()
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            if (IsElementSelected(i))
            {
                MoveUIElementOnYAxis(i, -ELEMENT_UI_OFFSET);
            } 
        }
        _selectedElements = 0;
    }
    private void MoveUIElementOnYAxis(int index, float yOffset)
    {
        _elements[index].transform.position += new Vector3(0, yOffset, 0);
    }
}
