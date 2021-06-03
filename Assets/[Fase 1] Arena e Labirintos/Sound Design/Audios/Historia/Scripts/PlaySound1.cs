using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent {
    public class PlaySound1 : MonoBehaviour
    {
        private bool isActivated = false;
        public string TextoDeSinalizacao = "Vire a esquerda";
        public GameObject positionMark;
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player" && !isActivated)
            {
                FindObjectOfType<AudioManager>().Play("2aparte");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
                isActivated = true;
                if (positionMark)
                    Destroy(positionMark);
            }
        }
    }
}