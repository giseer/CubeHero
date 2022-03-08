using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("General")]
    [SerializeField] private LifeBase lifeBase;

    [Header("Panels")] 
    [SerializeField] private GameObject InventoryPanel;

    [Header("Life")] 
    [SerializeField] private GameObject heartsContainer;
    [SerializeField] private GameObject heartPrefab;

    [Header("Exp")] 
    [SerializeField] private Image expFillContainer;
    

    private void Update()
    {
        HudUpdate();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventoryPanel();
        }
    }

    private void HudUpdate()
    {
        LifeHudUpdate();
    }

    private void LifeHudUpdate()
    {
        var containerTransform = heartsContainer.transform;
        
        if (containerTransform.childCount > lifeBase.Hearts)
        {
            Destroy(containerTransform.GetChild(containerTransform.childCount -1).gameObject);
        }
        if (containerTransform.childCount < lifeBase.Hearts)
        {
            Instantiate(heartPrefab, containerTransform);
        }
    }

    #region Panels

    private void ToggleInventoryPanel()
    {
        InventoryPanel.SetActive(!InventoryPanel.activeSelf);
    }
    #endregion
}