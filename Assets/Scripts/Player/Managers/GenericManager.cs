using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerManager {
	protected Player _player;

	public PlayerManager(Player playerRef) {
		_player = playerRef;
	}
	
	public abstract void PostInitialize();
}
