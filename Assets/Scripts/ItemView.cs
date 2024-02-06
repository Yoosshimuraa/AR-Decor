using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Button _selectionButton;

    private ItemData _itemData;

    public event UnityAction<ItemData> ItemSelected;
    public event UnityAction<ItemView> ItemDeselected;

    private void OnEnable()
    {
        _selectionButton.onClick.AddListener(onSelectionButtonClick);
    }

    private void OnDisable()
    {
        ItemDeselected?.Invoke(this);
        _selectionButton.onClick.RemoveListener(onSelectionButtonClick);
    }

    private void onSelectionButtonClick()
    {
        ItemSelected?.Invoke(_itemData);
    }

    public void Initialize(ItemData itemData)
    {
        _itemData = itemData;
        _image.sprite = itemData.Preview;
        _label.text = itemData.Label;
    }
}
