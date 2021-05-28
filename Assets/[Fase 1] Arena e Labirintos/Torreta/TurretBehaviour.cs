using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TurretBehaviour : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
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
        lineRenderer.SetPosition(1, (Vector3.forward * 10) + (Vector3.up*2));
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
            transform.parent.parent.LookAt(playerReference);
    }

    IEnumerator Shoot(float waitTime)
    {
        while (true)
        {
            Instantiate(enemyBullet, transform.parent.parent.position + transform.parent.parent.forward, transform.parent.parent.rotation, null);
            audioSource.Play();
            yield return new WaitForSeconds(waitTime);
        }
    }
}
