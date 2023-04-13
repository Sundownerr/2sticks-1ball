using System.Collections;
using UnityEngine;

namespace Game
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(IEnumerator routine);
    }
}