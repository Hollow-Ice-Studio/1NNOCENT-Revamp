using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;
using UnityEngine.Playables;

namespace innocent
{
    public class CutSceneDetector : MonoBehaviour
    {
        [SerializeField] string TextoOpcionalDeSinalizacao = "";
        [SerializeField] PlayableAsset cutscene;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                this.PostNotification(Notification.CUTSCENE_PLAY, cutscene);
                Destroy(this,0.5f);
                if(!string.IsNullOrEmpty(TextoOpcionalDeSinalizacao))
                {
                    this.PostNotification(Notification.HUD_WRITE, TextoOpcionalDeSinalizacao);
                }
            }
        }
    }
}