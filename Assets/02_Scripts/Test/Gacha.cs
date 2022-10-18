using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    #region 오브젝트 개수 방식
    /*전체가 100퍼 한 값이 오르면 한 값은 줄어드는 형식 -> 룰렛
     리스트 > 100/리스트 값 => 한 값의 확률이 나옴
     Debug.Log(Random.Range(0, 100)); 랜덤을 이렇게 쓰는 경우
     Debug.Log(100 / _rewardList.Count);

     
     //구하기
     리스트[0]은 본인 값 
     리스트[1]은 [0] + [1]
     리스트[2]는 [0] + [1] + [2]
      
     //조건
     랜덤 값 < 리스트[0]
     리스트[0]확률값 < 랜덤 값 < 리스트[0]확률값 + 리스트[1]확률값
     리스트[0]확률값 + 리스트[1]확률값 < 랜덤 값 < 리스트[0]확률값 + 리스트[1]확률값 + 리스트[2]확률값
     리스트[0]확률값 + 리스트[1]확률값 + 리스트[2]확률값 < 랜덤 값 < 리스트[0]확률값 + 리스트[1]확률값 + 리스트[2]확률값 + 리스트[3]확률값

     //예시
     랜덤 값 = 50;
     리스트 값 = 3 {0, 1, 2, 3}
     확률 = 25퍼
     
     50 < 25                                false
     25 < 50 < 25 + 25                      true
     25 + 25 < 50 < 25 + 25 + 25            false
     25 + 25 + 25 < 50 < 25 + 25 + 25 + 25  false
     */
    #endregion
    #region 가중치 방식
    /*가중치 방식
     //예시
     전체 값 = 29
     한 확률 10퍼
     29 * 10/100 = 2.9
     */
    #endregion

    [SerializeField] private List<GameObject> _rewardList;//리스트[i]번 보상
    [SerializeField] private List<float> _percentageList;//리스트[i]번 확률 써주기

    private List<float> _resultValueList = new List<float>();//계산된 확률
    //계산 결과 넣어주기 이러한 값 >> 전체값 * (확률값 / 100) >> 폐기
    //                           >> (확률값/총합) * 100
    /*리스트[i]번의 계산값을 넣어주기 위함 Ex)100일 때 30퍼는 => 30// 80일 때 30퍼는 => 24
      Debug.Log((_percentageList[0] + _percentageList[1]) * ( _percentageList[0] / 100));
    */

    private float _randomMaxValue;//확률 전부 더한 값
    private float _randomValue;//랜덤값

    private void Start()
    {
        foreach (var value in _percentageList)
        {
            _randomMaxValue += value; //전체값 구하기
        }
        for (int i = 0; i < _percentageList.Count; i++)
        {
            _resultValueList.Add((_percentageList[i] / _randomMaxValue) * 100);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartRandom();
        }
        RandomReward();
    }

    private void StartRandom()
    {
        _randomValue = Random.Range(1, _randomMaxValue);
    }

    private void RandomReward()
    {
        float preValue = 0f;
        float nextValue = 0f;

        nextValue += _resultValueList[0];

        if (_randomValue < _resultValueList[0]) //첫 리스트 확률값보다 작을 때의 보상 Ex) 랜덤값 < 25
        {
            //리스트[0]번째 보상주기
            print("0번 보상");
        }
        for (int i = 0; i < _resultValueList.Count - 1; i++) // Ex) i = 0일 때 preValue = 25 nextValue = 100 윗 줄에서 더해줌
        {
            preValue += _resultValueList[i];
            nextValue += _resultValueList[i + 1];
            if (preValue < _randomValue && nextValue > _randomValue)
            {
                //리스트[i + 1]번의 보상주기
                print($"{i +1}번 보상");
            }
        }


    }

}
