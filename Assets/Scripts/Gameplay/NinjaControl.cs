using System.Collections;
using System.Collections.Generic;
using OakFramework2;
using UnityEngine;
using UnityEngine.Experimental.Input;

namespace DefaultNamespace
{
    public class NinjaControl : MonoBehaviour, DefaultInput.IPlayerActions
    {
        public Collider2D leftLegRemoval;
        public Collider2D rightLegRemoval;

        public List<AudioClip> karateChops = new List<AudioClip>();
        
        [EnumFlag]
        public eDisabledInputType disabledInputsList;
        
        private Animator _animator;
        private Vector2 _randomSpan = new Vector2(2f,3f);
        private float _nextIdleChangeTime;
        private int _idleHash;
        private AudioSource _audioSource;

        public DefaultInput _input;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _animator = GetComponent<Animator>();
            _nextIdleChangeTime = Time.time + Random.Range(_randomSpan.x, _randomSpan.y);

            _idleHash = Animator.StringToHash("Idle");
            _input = new DefaultInput();
            
            
            PlayerState.instance.PlayerStateChangedEvent += OnPlayerStateChangedHandler;
        }        
        private void DisableInput()
        {
            _input.Disable();
        }

        private void Update()
        {
            if (Time.time > _nextIdleChangeTime)
            {
                var currIdle = _animator.GetFloat(_idleHash);
                float nextIdle = Mathf.Clamp(currIdle + (Random.Range(0f,1f) > 0.5f ? 1 : -1), 0f, 2f);
                StartCoroutine(ChangeIdleSmooth(0.25f, currIdle, nextIdle));

                _nextIdleChangeTime = Time.time + Random.Range(_randomSpan.x, _randomSpan.y);
            }
        }
        
        private void OnPlayerStateChangedHandler(ePlayerState obj)
        {
            switch (obj)
            {
                case ePlayerState.Normal:
                    _input.Player.Enable();
                    break;
                case ePlayerState.Distracted:
                case ePlayerState.InFlow:
                    _input.Player.Disable();
                    break;
            }
        }        

        private void OnEnable()
        {
            GameEvents.instance.TimesUp += DisableInput;
            GameEvents.instance.TimeEatenByDistractions += DisableInput;
            
            _input.Player.SetCallbacks(this);
            _input.Player.Enable();
        }

        private void OnDisable()
        {
            GameEvents.instance.TimesUp -= DisableInput;
            GameEvents.instance.TimeEatenByDistractions -= DisableInput;
            
            _input.Player.SetCallbacks(null);
            //_input.Player.Disable();
        }
        
        private IEnumerator ChangeIdleSmooth(float duration, float fromIdle, float toIdle)
        {
            var timeStart = Time.time;
            var timeEnd = Time.time + duration;
            while (Time.time < timeEnd)
            {
                _animator.SetFloat(_idleHash, Mathf.Lerp(fromIdle, toIdle, (Time.time - timeStart) / duration));
                yield return null;
            }
            
            _animator.SetFloat(_idleHash, toIdle);
        }

        public void ActivateRemoval(int leftOrRight)
        {
            ActivateLeg(leftOrRight, true);
        }
        
        public void DeactivateRemoval(int leftOrRight)
        {
            ActivateLeg(leftOrRight, false);            
        }

        private void ActivateLeg(int leftOrRight, bool activate)
        {
            if (leftOrRight == 0)
            {
                leftLegRemoval.enabled = activate;
            }
            else
            {
                rightLegRemoval.enabled = activate;
            }   
        }

        public void OnAttackRight(InputAction.CallbackContext context)
        {
            if (disabledInputsList.HasFlag(eDisabledInputType.Right))
                return;
            
            _animator.SetTrigger("PunchRight");
            PlayRandomKarateSound();
        }

        public void OnAttackLeft(InputAction.CallbackContext context)
        {
            if (disabledInputsList.HasFlag(eDisabledInputType.Left))
                return;            
            
            _animator.SetTrigger("PunchLeft");
            PlayRandomKarateSound();
        }

        public void OnAttackTop(InputAction.CallbackContext context)
        {
            if (disabledInputsList.HasFlag(eDisabledInputType.Top))
                return;            
            
            _animator.SetTrigger("PunchUp");
            PlayRandomKarateSound();
        }

        private void PlayRandomKarateSound()
        {
            if (_audioSource.isPlaying)
                _audioSource.Stop();

            _audioSource.clip = karateChops[Random.Range(0, karateChops.Count)];
            _audioSource.Play();
        }
    }
}