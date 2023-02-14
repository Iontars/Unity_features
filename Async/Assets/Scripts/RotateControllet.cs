using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControllet : MonoBehaviour
{
    [SerializeField] private Transform[] _usingPrefabs = default;
    private float _speed = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LifeCo());
        }
    }

    private IEnumerator LifeCo()
    {
        for (int i = 0; i < _usingPrefabs.Length; i++)
        {
            yield return StartCoroutine(RotatePrefabCo(_usingPrefabs[i],(i + 1)));
        }
    }

    private IEnumerator RotatePrefabCo(Transform prefab, float duration)
    {
        float timer = 0f;
        while (timer < 3f)
        {
            //timer = Mathf.Min(timer + Time.deltaTime/duration, 3f);
            timer += Time.deltaTime / duration;
            prefab.Rotate(Vector3.left, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
