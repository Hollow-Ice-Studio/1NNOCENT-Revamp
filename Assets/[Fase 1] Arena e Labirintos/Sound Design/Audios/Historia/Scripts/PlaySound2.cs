using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound2 : MonoBehaviour
    {
        public bool isActivated=false;
        public string TextoDeSinalizacao = "Caminho limpo! Vá em frente.";
        public GameObject positionMark;
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player" && !isActivated)
            {
                FindObjectOfType<AudioManager>().Play("Controle do Labirinto");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
                isActivated = true;
                if (positionMark)
                    Destroy(positionMark);
            }
        }
    }
}