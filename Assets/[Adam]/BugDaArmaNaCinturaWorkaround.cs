using System.Collections;
using UnityEngine;

public class BugDaArmaNaCinturaWorkaround : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineVirtualCamera workaroundCamera;
    [SerializeField] Cinemachine.CinemachineFreeLook adamCamera;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("fastCameraPriorityChange");
        }
    }
    IEnumerator fastCameraPriorityChange()
    {
        yield return new WaitForSeconds(1f);
        var originalPriority = adamCamera.Priority;
        workaroundCamera.Priority = 100;
        yield return new WaitForSeconds(1.5f);
        adamCamera.Priority = 0;
        yield return new WaitForSeconds(1.5f);
        adamCamera.Priority = originalPriority;
        workaroundCamera.Priority = 0;
    }
}
