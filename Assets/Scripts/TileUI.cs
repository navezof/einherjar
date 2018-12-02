using UnityEngine;
using UnityEngine.UI;

public class TileUI : GameUI
{
    Tile tile;

    void Update()
    {
        base.Update();
    }

    public override void SetSubject(GameObject owner)
    {
        if (!tile)
            print("tile is null");

        tile = owner.GetComponent<Tile>();
    }

    #region Events
    public void OnBuildBtnClicked()
    {
        this.tile.build();
    }
    #endregion
}
