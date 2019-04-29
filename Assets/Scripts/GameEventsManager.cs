using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace DefaultNamespace
{
    public class GameEventsManager : MonoBehaviour
    {
        public Animator ninjaAnimator;
        public List<ParticleSystem> shieldPS;
        public Animator flowReachedTextAnim;
        public Animator distractedTextAnim;
        public Animator levelCompleteAnim;
        public Animator timeDistractedAnim;

        public AudioSource gameEventAudioSource;
        public AudioSource levelEndAudioSource;

        public AudioClip flowReachedClip;
        public AudioClip distractedClip;
        public AudioClip levelCompleteClip;
        public AudioClip levelFailedClip;
        
        private void Awake()
        {
            GameEvents.instance.FlowReached += OnFlowReachedHandler;
            GameEvents.instance.FocusDepleted += OnFocusDepletedHandler;
            GameEvents.instance.TimesUp += OnTimesUpHandler;
            GameEvents.instance.TimeEatenByDistractions += OnTimeEatenByDistractionsHandler;
        }

        private void OnTimeEatenByDistractionsHandler()
        {
            timeDistractedAnim.gameObject.SetActive(true);
            timeDistractedAnim.SetTrigger("textAnim");
            ninjaAnimator.SetTrigger("StartDistracted");
            levelEndAudioSource.clip = levelFailedClip;
            levelEndAudioSource.Play();
        }

        private void OnTimesUpHandler()
        {
            levelCompleteAnim.gameObject.SetActive(true);
            levelCompleteAnim.SetTrigger("textAnim");
            levelEndAudioSource.clip = levelCompleteClip;
            levelEndAudioSource.Play();

            //TODO: trigger transition to next level after some while
        }

        private void OnFocusDepletedHandler()
        {
            if (PlayerState.instance.State != ePlayerState.Normal)
                return;
            
            distractedTextAnim.gameObject.SetActive(true);
            distractedTextAnim.SetTrigger("textAnim");
            ninjaAnimator.SetTrigger("StartDistracted");
            PlayerState.instance.State = ePlayerState.Distracted;
            gameEventAudioSource.clip = distractedClip;
            gameEventAudioSource.Play();
            transform.DOScale(transform.localScale, Locator.Instance.ProjectConstants.DistractedDuration).onComplete +=
                OnDistractedEnded;
        }

        private void OnDistractedEnded()
        {
            if (PlayerState.instance.State != ePlayerState.Distracted)
                return;            
            
            ninjaAnimator.SetTrigger("EndDistracted");
            PlayerState.instance.State = ePlayerState.Normal;
            GameStats.instance.Focus = Locator.Instance.ProjectConstants.FocusAfterDeplete *
                                       Locator.Instance.ProjectConstants.MaxFocus;
        }

        private void OnFlowReachedHandler()
        {
            if (PlayerState.instance.State != ePlayerState.Normal)
                return;

            // activate the shield
            shieldPS.ForEach(ps => ps.Play());
            ninjaAnimator.SetTrigger("StartFlow");
            PlayerState.instance.State = ePlayerState.InFlow;
            flowReachedTextAnim.gameObject.SetActive(true);
            flowReachedTextAnim.SetTrigger("FlowAnim");
            gameEventAudioSource.clip = flowReachedClip;
            gameEventAudioSource.Play();
            gameEventAudioSource.volume = 0.0f;
            gameEventAudioSource.DOFade(1.0f, 3.0f);
            
            transform.DOScale(transform.localScale, Locator.Instance.ProjectConstants.FlowDuration).onComplete +=
                OnFlowEnded;            
        }

        private void OnFlowEnded()
        {
            if (PlayerState.instance.State != ePlayerState.InFlow)
                return;
            
            ninjaAnimator.SetTrigger("EndFlow");
            _checkForFlowEnd = true;
            gameEventAudioSource.DOFade(0.0f, 4.0f);
        }

        private bool _checkForFlowEnd;
        private void Update()
        {
            if (_checkForFlowEnd && ninjaAnimator.GetCurrentAnimatorStateInfo(0).IsName("ReturnFromFlow") &&
                ninjaAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
                PlayerState.instance.State = ePlayerState.Normal;
                shieldPS.ForEach(ps => ps.Stop());
                // remove the shield
            
                GameStats.instance.Focus = Locator.Instance.ProjectConstants.FocusAfterFlow *
                                           Locator.Instance.ProjectConstants.MaxFocus;
                _checkForFlowEnd = false;
            }
        }
    }
}