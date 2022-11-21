using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float _SpikeOnDelay = 0.5f;
    public bool _isSpikeOff;

    private Animator _spikeAnimator;
    private PlayerCheck _playerCheck;

    private void Awake()
    {
        _spikeAnimator = gameObject.GetComponent<Animator>();
        _playerCheck = FindObjectOfType<PlayerCheck>();
    }

    public void SpikeOn() => _spikeAnimator.SetBool("SpikeOn", true);
    public void SpikeOff() => _spikeAnimator.SetBool("SpikeOff", true);
    public void SpikeReset() 
    {
        _spikeAnimator.SetBool("SpikeOn", false);
        _spikeAnimator.SetBool("SpikeOff", false);
    }
        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("SpikeTrapOn");
            if (_isSpikeOff)
            {
                StartCoroutine("SpikeTrapOff");
            }
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

    IEnumerator SpikeTrapOff()
    {
        yield return StartCoroutine(SpikeTrapOn());
        yield return new WaitForSecondsRealtime(1f);
        SpikeOff();
        yield return new WaitForSecondsRealtime(0.5f);
        SpikeReset();
    }


}
