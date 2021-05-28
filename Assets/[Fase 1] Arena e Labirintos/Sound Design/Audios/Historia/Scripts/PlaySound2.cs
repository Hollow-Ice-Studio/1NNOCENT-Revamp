using System.Collections;
using System.Collections.Generic;
using TheLiquidFire.Notifications;
using UnityEngine;

namespace innocent
{
    public class PlaySound2 : MonoBehaviour
    {
        public bool activated=false;
        public string TextoDeSinalizacao = "Caminho limpo! Vá em frente.";
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player"&&!activated)
            {
                activated = true;
                FindObjectOfType<AudioManager>().Play("Controle do Labirinto");
                this.PostNotification(Notification.HUD_WRITE, TextoDeSinalizacao);
            }
        }
    }
}