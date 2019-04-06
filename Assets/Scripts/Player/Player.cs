using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DBLite;
using RTS.UI;

public class Player : MonoBehaviour {
	private UnitManager _unitManager;
	private InteractionManager _interactionManager;
	private ResourceManager _resourceManager;
    //private UIController _uiController;
    // private DBLite.DBLite _playerDB;
    private UIManager _uiManager;
    private OrderManager _orderController;

	public UnitManager UnitManager { get { return _unitManager; } }
	public ResourceManager ResourceManager { get { return _resourceManager; } }
	// public UIController UIController { get { return _uiController; } }
	public InteractionManager InteractionManager { get { return _interactionManager; } }
    public UIManager UIManager { get { return _uiManager; } }
    public OrderManager OrderController { get { return _orderController; } }

    // public DBLite.DBLite PlayerDB { get { return _playerDB; }}
    public UIContext UIContext;

	public Player() {
		// initialize non-GameObjects
		// _playerDB = new DBLite.DBLite("PlayerDB");
		// _uiController = new UIController(this);
		_unitManager = new UnitManager(this);
		_resourceManager = new ResourceManager(this);
		_interactionManager = new InteractionManager(this);
        _uiManager = new UIManager(this);
        _orderController = new OrderManager(this);
	}

	public void Start() {
        // tell the non-GameObject classes that initialization is complete
		_resourceManager.PostInitialize();
		_interactionManager.PostInitialize();
        _uiManager.PostInitialize();
        _orderController.PostInitialize();
		// _uiController.PostInitialize();
		// _uiBehaviour.OnSelectInteractable.AddListener((Interactable interactable) => {
		// 	Debug.Log("Selected interactable via UI with name " + interactable.name);
		// 	_interactionManager.SetSelection(interactable);
		// });
	}
}
