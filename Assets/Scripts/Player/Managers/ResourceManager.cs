using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

public class ResourceManager : PlayerManager {
	public int wood = 0;
	public int stone = 0;

	public ResourceManager(Player _playerRef) : base(_playerRef) {
		//
	}

	public override void PostInitialize() {
        _player.UIManager.SetResourceValue(ResourceType.wood, wood);
        _player.UIManager.SetResourceValue(ResourceType.stone, stone);
		// _player.UIController.SetValue("R_WOOD", wood);
		// _player.UIController.SetValue("R_STONE", stone);
	}

	public void AddResource(int amount, ResourceType resource) {
		switch(resource) {
			case ResourceType.wood:
				wood += amount;
				_player.UIManager.SetResourceValue(ResourceType.wood, wood);
				break;
			case ResourceType.stone:
				stone += amount;
				_player.UIManager.SetResourceValue(ResourceType.stone, stone);
				break;
			default: 
				Debug.Log("Attempted to add invalid resource type " + resource);
				break;
		}
	}
}
