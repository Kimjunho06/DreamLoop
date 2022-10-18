using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    #region ������Ʈ ���� ���
    /*��ü�� 100�� �� ���� ������ �� ���� �پ��� ���� -> �귿
     ����Ʈ > 100/����Ʈ �� => �� ���� Ȯ���� ����
     Debug.Log(Random.Range(0, 100)); ������ �̷��� ���� ���
     Debug.Log(100 / _rewardList.Count);

     
     //���ϱ�
     ����Ʈ[0]�� ���� �� 
     ����Ʈ[1]�� [0] + [1]
     ����Ʈ[2]�� [0] + [1] + [2]
      
     //����
     ���� �� < ����Ʈ[0]
     ����Ʈ[0]Ȯ���� < ���� �� < ����Ʈ[0]Ȯ���� + ����Ʈ[1]Ȯ����
     ����Ʈ[0]Ȯ���� + ����Ʈ[1]Ȯ���� < ���� �� < ����Ʈ[0]Ȯ���� + ����Ʈ[1]Ȯ���� + ����Ʈ[2]Ȯ����
     ����Ʈ[0]Ȯ���� + ����Ʈ[1]Ȯ���� + ����Ʈ[2]Ȯ���� < ���� �� < ����Ʈ[0]Ȯ���� + ����Ʈ[1]Ȯ���� + ����Ʈ[2]Ȯ���� + ����Ʈ[3]Ȯ����

     //����
     ���� �� = 50;
     ����Ʈ �� = 3 {0, 1, 2, 3}
     Ȯ�� = 25��
     
     50 < 25                                false
     25 < 50 < 25 + 25                      true
     25 + 25 < 50 < 25 + 25 + 25            false
     25 + 25 + 25 < 50 < 25 + 25 + 25 + 25  false
     */
    #endregion
    #region ����ġ ���
    /*����ġ ���
     //����
     ��ü �� = 29
     �� Ȯ�� 10��
     29 * 10/100 = 2.9
     */
    #endregion

    [SerializeField] private List<GameObject> _rewardList;//����Ʈ[i]�� ����
    [SerializeField] private List<float> _percentageList;//����Ʈ[i]�� Ȯ�� ���ֱ�

    private List<float> _resultValueList = new List<float>();//���� Ȯ��
    //��� ��� �־��ֱ� �̷��� �� >> ��ü�� * (Ȯ���� / 100) >> ���
    //                           >> (Ȯ����/����) * 100
    /*����Ʈ[i]���� ��갪�� �־��ֱ� ���� Ex)100�� �� 30�۴� => 30// 80�� �� 30�۴� => 24
      Debug.Log((_percentageList[0] + _percentageList[1]) * ( _percentageList[0] / 100));
    */

    private float _randomMaxValue;//Ȯ�� ���� ���� ��
    private float _randomValue;//������

    private void Start()
    {
        foreach (var value in _percentageList)
        {
            _randomMaxValue += value; //��ü�� ���ϱ�
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

        if (_randomValue < _resultValueList[0]) //ù ����Ʈ Ȯ�������� ���� ���� ���� Ex) ������ < 25
        {
            //����Ʈ[0]��° �����ֱ�
            print("0�� ����");
        }
        for (int i = 0; i < _resultValueList.Count - 1; i++) // Ex) i = 0�� �� preValue = 25 nextValue = 100 �� �ٿ��� ������
        {
            preValue += _resultValueList[i];
            nextValue += _resultValueList[i + 1];
            if (preValue < _randomValue && nextValue > _randomValue)
            {
                //����Ʈ[i + 1]���� �����ֱ�
                print($"{i +1}�� ����");
            }
        }


    }

}
