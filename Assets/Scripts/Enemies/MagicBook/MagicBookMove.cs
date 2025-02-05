using DG.Tweening;
using UnityEngine;

public class MagicBook : MonoBehaviour
{
    [SerializeField] private float durationAnimationPath = 2f;
    [SerializeField] private PathType pathType = PathType.CatmullRom;
    [SerializeField] private Vector3[] weypoints;
    
    private Tween _tween;

    private void Start()
    {
        var transform = GetComponent<Transform>();

        _tween = transform.DOPath(weypoints, durationAnimationPath, pathType);
        
        _tween.SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
