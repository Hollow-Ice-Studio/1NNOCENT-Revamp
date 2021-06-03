using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound : MonoBehaviour
    {
        private bool isActivated = false;
        public string TextoDeSinalizacao;
        public string AudioManagerSoundName;
        public GameObject positionMark;
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player" && !isActivated)
            {
                FindObjectOfType<AudioManager>().Play(AudioManagerSoundName);
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
                isActivated = true;
                if (positionMark)
                    Destroy(positionMark);
            }
        }
    }
}