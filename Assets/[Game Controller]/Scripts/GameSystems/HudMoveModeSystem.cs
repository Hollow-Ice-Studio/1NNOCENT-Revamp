using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace innocent
{
    public class HudMoveModeSystem : GameSystem
    {
        HudMoveModeSystem() => NotificationName = Notification.HUD_SWITCH_MOVE_MODE;
        [SerializeField] Texture UiSpriteDefaultMoveMode;
        [SerializeField] Texture UiSpriteSprintingMoveMode;
        [SerializeField] RawImage UiRawImageElement;
        bool isSprinting = false;
        protected override void NotificationHandler(object sender, object args)
        {
            if ((bool)args)
                UiRawImageElement.texture = UiSpriteSprintingMoveMode;
            else
                UiRawImageElement.texture = UiSpriteDefaultMoveMode;
        }
    }
}