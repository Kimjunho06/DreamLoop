using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float _SpikeOnDelay = 0.5f;

    private Animator _spikeAnimator;
    private PlayerCheck _playerCheck;

    private void Awake()
    {
        _spikeAnimator = gameObject.GetComponent<Animator>();
        _playerCheck = FindObjectOfType<PlayerCheck>();
    }
    
    public void SpikeOn() => _spikeAnimator.SetBool("SpikeOn", true);
    public void SpikeOff() => _spikeAnimator.SetBool("SpikeOn", true);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("SpikeTrapOn");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerCheck.Die();
        }
    }

    IEnumerator SpikeTrapOn()
    {
        yield return new WaitForSecondsRealtime(_SpikeOnDelay);
        SpikeOn();
    }
}
