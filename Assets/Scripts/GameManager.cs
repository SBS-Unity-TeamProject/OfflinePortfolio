using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //파일깨짐
        public Vector2 player = Move.InputVector2;
        // �̱��� ������ ����ϱ� ���� �ν��Ͻ� ����
        private static GameManager _instance;
        // �ν��Ͻ��� �����ϱ� ���� ������Ƽ
        public static GameManager Instance
        {
            get
            {
                // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ����ش�.
                if (!_instance)
                {
                    _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                    if (_instance == null)
                        Debug.Log("no Singleton obj");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� �����Ѵ�.
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
            // �Ʒ��� �Լ��� ����Ͽ� ���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� �ʴ´�.
            DontDestroyOnLoad(gameObject);
        }
    }
