using System.Collections;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;

namespace Lesson24
{
    public class AsyncScript: MonoBehaviour
    {
        protected async void Start()
        {
            StartCoroutine(Moving());
            await MovingAsync();
        }

        //Курутина
        private IEnumerator Moving()
        {
            while (true)
            {
                var _timer = 2f;
                while (_timer > 0f)
                {
                    _timer -= Time.deltaTime;
                    transform.position += Vector3.right * Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(2f);

                _timer = 2f;
                while (_timer > 0f)
                {
                    _timer -= Time.deltaTime;
                    transform.position -= Vector3.right * Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(2f); //Задержка между функциями
            }
        }

        //Асинхронный метод
        private async Task MovingAsync()
        { 
            while(true)
            {
           var _timer = 2f;
                while (_timer > 0f)
                {
                    _timer -= Time.deltaTime;
                    transform.position += Vector3.up * Time.deltaTime;
                    await Task.Yield();

                    //if (!EditorApplication.isPlaying) return;
                }
                await Task.Delay(TimeSpan.FromSeconds(2)); //Задержка между функциями

                _timer = 2f;
                while (_timer > 0f)
                {
                    _timer -= Time.deltaTime;
                    transform.position -= Vector3.up * Time.deltaTime;
                    await Task.Yield();
                }
                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }

}
