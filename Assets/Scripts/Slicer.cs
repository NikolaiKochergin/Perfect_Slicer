using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using BzKovSoft.ObjectSlicer;
using BzKovSoft.ObjectSlicerSamples;

public class Slicer : MonoBehaviour
{
    [SerializeField] private GameObject _blade;
    [SerializeField] private float _duration;
    [SerializeField] private float _offsetY;

    private BzKnife _knife;
    private StunRecorder _stanRecorder;
    private float _currentTime;

    private void Awake()
    {
        _knife = _blade.GetComponentInChildren<BzKnife>();
        _stanRecorder = _blade.GetComponentInChildren<StunRecorder>();
        _currentTime = _duration;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _duration)
        {
            if (Input.GetMouseButton(0))
            {
                _knife.BeginNewSlice();
                _blade.transform.DOMoveY(_blade.transform.position.y - _offsetY, _duration / 2f).SetLoops(2, LoopType.Yoyo);
                _currentTime = 0;
            }
        }
    }

    private void OnEnable()
    {
        _stanRecorder.Stunnig += OnStunnig;
    }

    private void OnDisable()
    {
        _stanRecorder.Stunnig -= OnStunnig;
    }

    private void OnStunnig()
    {
        _currentTime -= _duration * 2;
    }
}
