using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogButton : MonoBehaviour
{
    [SerializeField] private RectTransform _startGameButton;
    [SerializeField] private RectTransform _continueGameButton;
    [SerializeField] private RectTransform _dataManagementButton;
    [SerializeField] private RectTransform _endButton;
    [SerializeField] private RectTransform _creditButton;
    [SerializeField] private RectTransform _clickToStartText;
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _subTitleText;
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private Vector3 _movePosition;
    [SerializeField] private float _scalingTime;
    [SerializeField] private float _scalingTimeText;
    [SerializeField] private float _fadeTime;

    public void PlayTitleDialogSequence()
    {
        _titleText.DOFade(endValue: 0f,duration: _fadeTime);
        _subTitleText.DOFade(endValue: 0f,duration: _fadeTime);
        _clickToStartText.DOScale(Vector3.zero,_scalingTimeText);
        _startGameButton.DOScale(new Vector3(_maxScale.x,_maxScale.y,_maxScale.z),_scalingTime);
        _continueGameButton.DOScale(new Vector3(_maxScale.x,_maxScale.y,_maxScale.z),_scalingTime);
        _dataManagementButton.DOScale(new Vector3(_maxScale.x,_maxScale.y,_maxScale.z),_scalingTime);
        _endButton.DOScale(new Vector3(_maxScale.x,_maxScale.y,_maxScale.z),_scalingTime);
        _creditButton.DOScale(new Vector3(_maxScale.x,_maxScale.y,_maxScale.z),_scalingTime);
    }
}
