using UnityEngine;
namespace innocent
{
    public class AtivamentoPrimeiroInimigo : MonoBehaviour
    {
        private bool isActivated = false;
        [SerializeField]
        GameObject firstStoryEnemy, nextAudioTrigger;
        private void Start()
        {
            firstStoryEnemy.SetActive(false);
            nextAudioTrigger.SetActive(false);
        }
        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player" && !isActivated)
            {
                isActivated = true;
                firstStoryEnemy.SetActive(true);
                nextAudioTrigger.SetActive(true);
            }
        }
    }
}