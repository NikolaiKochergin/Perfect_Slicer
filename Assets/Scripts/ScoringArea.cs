using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoringArea : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            _score += 50;
            _text.SetText("Score: " + _score.ToString());
        }
        Destroy(other.gameObject);
    }
}
