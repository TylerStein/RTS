using RTS.Entities;
using RTS.UI;

public class UIManager : PlayerManager
{
    public UIManager(Player owner) : base(owner)
    {
        //
    }

    public void SetSelectedEntity(Entity entity)
    {
        _player.UIContext.SetContextEntity(entity);
    }

    public void ClearSelectedEntity()
    {
        _player.UIContext.ClearContextEntity();
    }

    public void SetResourceValue(ResourceType resourceType, int value)
    {
        _player.UIContext.SetResourceValue(resourceType, value);
    }

    public override void PostInitialize()
    {
        //
    }
}
