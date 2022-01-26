using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Player player;

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
        
        if (containerTransform.childCount > player.Hearts)
        {
            Destroy(containerTransform.GetChild(containerTransform.childCount -1).gameObject);
        }
        if (containerTransform.childCount < player.Hearts)
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
