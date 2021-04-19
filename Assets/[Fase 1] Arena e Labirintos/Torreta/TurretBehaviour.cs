using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TurretBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform playerReference;
    [SerializeField]
    GameObject enemyBullet;
    [Range(1,10)]
    public float shootingFrequency;
    // Start is called before the first frame update
    void Awake()
    {
        var lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(1, Vector3.forward * 10);
        lineRenderer.startWidth = 0.1f;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Turret enter");
        if(other.tag == "Player")
        {
            playerReference = other.transform;
            StartCoroutine(Shoot(shootingFrequency));
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            playerReference = null;
        }
            
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(playerReference)
            transform.LookAt(playerReference);
    }

    IEnumerator Shoot(float waitTime)
    {
        while (true)
        {
            Instantiate(enemyBullet, transform.position + transform.forward, transform.rotation, null);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
