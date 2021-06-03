using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound3 : MonoBehaviour
    {
        private bool isActivated = false;
        public string TextoDeSinalizacao = "Adam, perdemos o acesso à esse trecho. Encontre uma saída.";
        public GameObject positionMark;
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player" && !isActivated)
            {
                FindObjectOfType<AudioManager>().Play("Perder Acesso");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
                isActivated = true;
                if (positionMark)
                    Destroy(positionMark);
            }
        }
    }
}