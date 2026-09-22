using System;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    // NEEDS VALIDATION: экран/условие поражения не засняты в референсе (REFERENCE_SPEC §1, §11).
    // Универсальный компонент — вешается на любой объект, касание которого должно
    // мгновенно завершать забег поражением. Конкретный объект (какой именно) не выбран
    // намеренно, это решение дизайнера уровня (Step 15), не код.
    public event Action OnPlayerLost;

    void OnTriggerEnter(Collider other)
    {
        var state = other.GetComponentInParent<PlayerWealthState>();
        if (state == null)
            return;

        OnPlayerLost?.Invoke();
    }
}
