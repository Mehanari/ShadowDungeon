using UnityEngine;

public class AngularRotationComponent : MonoBehaviour
{
    [SerializeField] private GameObject _toRotate;
    [SerializeField] private float _xAxisSpeed;
    [SerializeField] private float _yAxisSpeed;
    [SerializeField] private float _zAxisSpeed;

    private void Update()
    {
        Vector3 current = _toRotate.transform.eulerAngles;
        current += new Vector3(_xAxisSpeed, _yAxisSpeed, _zAxisSpeed);
        _toRotate.transform.eulerAngles = current;
    }
}
