using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace innocent
{
    public class DestroyOnCollision : MonoBehaviour
    {
        [SerializeField] float DestroyAfterNSeconds;
        float bornTime;
        private void Start()
        {
            bornTime = Time.deltaTime;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (bornTime - Time.deltaTime > DestroyAfterNSeconds)
                Destroy(this.gameObject);
        }
    }
}

