using System;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class InventoryHUDController : MonoBehaviour
{
    public int score;
    
    private Label _label;
    private ProgressBar _lifeBar;
    private VisualElement _inventoryContainer;
    [SerializeField]
    private VisualTreeAsset invItemTemplate;

    private void OnEnable()
    {
        EventBus.CoinPickedUp += OnCoinPickedUp;
        EventBus.DamageTaken += OnDamageTaken;
        EventBus.InventoryItemPickedUp += EventBusOnInventoryItemPickedUp;
    }


    private void OnDisable()
    {
        EventBus.CoinPickedUp -= OnCoinPickedUp;
        EventBus.DamageTaken -= OnDamageTaken;
        EventBus.InventoryItemPickedUp -= EventBusOnInventoryItemPickedUp;
    }
    

    private void Start()
    {
        var root = GetComponent<UIDocument>();
        Assert.IsNotNull(root, "root != null");

        _label = root.rootVisualElement.Q<Label>("Score");
        _lifeBar = root.rootVisualElement.Q<ProgressBar>();
        _inventoryContainer = root.rootVisualElement.Q<VisualElement>("ItemsContainer");
    }
    
    private void EventBusOnInventoryItemPickedUp(PickUpObj obj)
    {
        var newItem = invItemTemplate.Instantiate();
        newItem.dataSource = obj;
        _inventoryContainer.Add(newItem);
    }

    public void OnCoinPickedUp()
    {
        score += 10;
        _label.text = $"Score: {score}";
    }

    public void OnDamageTaken(int damage)
    {
        _lifeBar.value -= damage;
    }
}
