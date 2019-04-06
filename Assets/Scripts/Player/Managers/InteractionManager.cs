using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using RTS.Entities;

public class InteractionManager : PlayerManager {
	public Entity selection = null;
	
	public InteractionManager(Player playerRef) : base(playerRef) {
		//
	}

	public override void PostInitialize() {
		//
	}

	public void ClearSelection() {
		if (selection != null) {
			selection.OnUnfocus(this);
            _player.UIManager.ClearSelectedEntity();
			// _player.UIController.SetValue("C_NAME", "");
			// _player.UIController.SetValue("C_SPRITE", (object)null);
			// _player.UIController.SetValue("C_ORDERS", (object)null);
			selection = null;
		}
	}

	public void SetSelection(Entity entity) {
		selection = entity;
        _player.UIManager.SetSelectedEntity(entity);
		// _player.UIController.SetValue("C_NAME", selection.displayName);
		// _player.UIController.SetValue("C_SPRITE", (object)selection.entitySprite);
		// _player.UIController.SetValue("C_ORDERS", (object)selection.orderPool.availableOrders.ToArray());
		selection.OnFocus(this);
	}

	public void ResolvePrimaryClick(ClickContext ctx, bool shifted = false) {
        if (EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log("Clicked UI");
        } else {
            if (ctx.hasObject) {
                Entity entity = ctx.Thing.GetComponent<Entity>();
                if (entity != null) OnPrimaryClickedEntity(entity, ctx.Point, shifted);
                else OnPrimaryClickedOther(ctx.Thing, ctx.Point, shifted);
            }
        }
	}

	public void ResolveSecondaryClick(ClickContext ctx, bool shifted = false) {
        if (EventSystem.current.IsPointerOverGameObject()) {
            Debug.Log("Clicked UI");
        } else {
            if (ctx.hasObject) {
                Entity entity = ctx.Thing.GetComponent<Entity>();
                if (entity != null) OnSecondaryClickedEntity(entity, ctx.Point, shifted);
                else OnSecondaryClickedOther(ctx.Thing, ctx.Point, shifted);
            }
        }
	}

	// Primary clicking an Entity makes it the selection
	public void OnPrimaryClickedEntity(Entity entity, Vector3 point, bool additive = false) {
		if (entity != selection) {
			ClearSelection();
			SetSelection(entity);
		}
	}

	public void OnPrimaryClickedOther(GameObject other, Vector3 point, bool additive = false) {
		if (selection && other.gameObject != selection.gameObject) ClearSelection();
	}

	public void OnSecondaryClickedEntity(Entity entity, Vector3 point, bool additive = false) {
		if (selection) selection.OnSecondaryClickEntity(entity, point, additive);
	}

	public void OnSecondaryClickedOther(GameObject other, Vector3 point, bool additive = false) {
		if (selection) selection.OnSecondaryClickOther(other, point, additive);
	}
}
