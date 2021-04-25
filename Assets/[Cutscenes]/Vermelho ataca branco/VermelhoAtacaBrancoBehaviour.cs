using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace innocent
{
    public class VermelhoAtacaBrancoBehaviour : MonoBehaviour
    {
        [SerializeField] PlayableDirector timelineDirector;
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                timelineDirector.Play();
            }
        }
    }
}