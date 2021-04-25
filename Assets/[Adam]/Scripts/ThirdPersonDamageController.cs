using UnityEngine;
using TheLiquidFire.Notifications;

namespace innocent
{
    public class ThirdPersonDamageController : MonoBehaviour
    {
        [Header("Adicione uma referência")]
        [SerializeField]
        GameObject DyingModelPrefab;
        [Range(0,1000)]
        public float limiteVerticalDoMapa;
        [Range(1, 100)]
        public int LifeValue;


        void Start()
        {
            if (DyingModelPrefab == null)
                throw new System.Exception("Adicione uma prefab no script");
        }

        void Update()
        {
            if(transform.position.y < -limiteVerticalDoMapa
                || transform.position.y > limiteVerticalDoMapa)
            {
                die();
            }
        }
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.tag == ConfiguredTags.ENEMY)
            {
                if (LifeValue <= 0)
                    die();
                else
                    hurt();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == ConfiguredTags.ENEMY)
            {
                if (LifeValue <= 0)
                    die();
                else
                    hurt();
            }
        }

        void hurt()
        {
            LifeValue--;
            this.PostNotification(Notification.HUD_HURT);
        }

        void die()
        {
            Instantiate(DyingModelPrefab, this.transform.position, this.transform.rotation, null);
            Destroy(this.gameObject);
        }
    }
}