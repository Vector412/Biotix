using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAnim : MonoBehaviour
{
    [SerializeField] Animator speedCircle;

    private void Start()
    {
        speedCircle = GetComponent<Animator>();
        speedCircle.speed = Random.Range(0.2f, 0.5f);
    }
}