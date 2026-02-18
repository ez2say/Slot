using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using DG.Tweening;

namespace Lootbox.Animation
{
    public class SimplePulseAnimation : MonoBehaviourExt
    {
        [Header("Targets")]

        [Header("Pulse Settings")]
        [SerializeField] private float _duration = 1.2f;
        [SerializeField] private float _maxScale = 1.08f;
        [SerializeField] private Color _glowColor = new Color(1f, 0.9f, 0.5f);

        [Header("Start Settings")]
        [SerializeField] private bool _playOnAwake = true;

        private Transform _targetTransform;
        private Graphic _targetGraphic;
        private Vector3 _originalScale;
        private Color _originalColor;
        private Sequence _pulseSequence;

        [OnAwake]
        private void Initialize()
        {
            _targetTransform = transform.GetComponent<Transform>();
            _targetGraphic = transform.GetComponent<Graphic>();

            _originalScale = _targetTransform.localScale;
            _originalColor = _targetGraphic.color;
        }

        [OnStart]
        private void Play()
        {
            if (_playOnAwake)
                StartPulse();
        }

        public void StartPulse()
        {
            StopPulse();
            _pulseSequence = DOTween.Sequence();
            _pulseSequence.SetLoops(-1, LoopType.Yoyo);

            _pulseSequence.Append(
                _targetTransform.DOScale(_originalScale * _maxScale, _duration / 2)
                    .SetEase(Ease.InOutSine)
            );


            _pulseSequence.Join(
                _targetGraphic.DOColor(_glowColor, _duration / 2)
                    .SetEase(Ease.InOutSine)
            );

            _pulseSequence.Play();
        }

        public void StopPulse()
        {
            _pulseSequence?.Kill();

            _targetTransform.localScale = _originalScale;
            _targetGraphic.color = _originalColor;
        }

        [OnDestroy]
        private void Cleanup()
        {
            StopPulse();
        }
    }
}
