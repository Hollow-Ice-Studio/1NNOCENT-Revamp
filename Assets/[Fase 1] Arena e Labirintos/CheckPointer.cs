using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointer : MonoBehaviour
{
    [SerializeField]
    Transform AdamTransform;
    [SerializeField]
    Animator animationHint;
    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        AdamTransform.position = new Vector3(
            PlayerPrefs.GetFloat("x", AdamTransform.position.x),//60
            PlayerPrefs.GetFloat("y", AdamTransform.position.y),//1
            PlayerPrefs.GetFloat("z", AdamTransform.position.z)//235
            );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !activated)
        {
            animationHint.SetTrigger("play");
            activated = true;
            PlayerPrefs.SetFloat("x",other.transform.position.x);
            PlayerPrefs.SetFloat("y",other.transform.position.y);
            PlayerPrefs.SetFloat("z",other.transform.position.z);
            PlayerPrefs.Save();
        }
    }
}
