using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace innocent
{
    public class VermelhoAtacaBrancoBehaviour : MonoBehaviour
    {
        public bool activated=false;
        [SerializeField] PlayableDirector timelineDirector;
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && !activated)
            {
                activated = true;
                timelineDirector.Play();
            }
        }
    }
}