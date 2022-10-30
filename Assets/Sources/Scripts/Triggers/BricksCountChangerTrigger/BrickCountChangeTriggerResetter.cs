using UnityEngine;

public class BrickCountChangeTriggerResetter
{
    private Transform _object;
    private Vector3 _startPosition;
    private Transform _startParent;

    public BrickCountChangeTriggerResetter(Transform objectTrasform)
    {
        _startPosition =  objectTrasform.position;
        _startParent = objectTrasform.parent;
        _object = objectTrasform;
    }

    public void ResetTrigger()
    {
        _object.SetParent(_startParent);
        _object.position = _startPosition;
        _object.gameObject.SetActive(true);
    }
}
