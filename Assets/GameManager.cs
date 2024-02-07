using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �V�[��
    public int SceneFlag = 0;

    // �v���C���[
    public Text PlayerWindowtextComponent;
    public Text PlayerArrowtextComponent;
    public Text PlayerHPtextComponent;
    private int PlayerBattlefaze = 0;
    private int PlayerBattleTime = 0;
    private int PlayerArrowpos = 0;
    private int PlayerHP = 50;

    // �G�l�~�[
    public Text EnemyBattletextComponent;
    public Text EnemyHPtextComponent;
    private int EnemyBattlefaze = 0;
    private int EnemyBattleTime = 0;
    private int EnemyHP = 20;
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;

        PlayerWindowtextComponent.text = "���U��\n�@��\n�@���@";
        PlayerHPtextComponent.text = "PlayerHP : " + PlayerHP;
        EnemyHPtextComponent.text = "EnemyHP : " + EnemyHP;
        EnemyBattletextComponent.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        switch(SceneFlag)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneFlag = 1;
                    SceneManager.LoadScene("SampleScene");
                }
                break;
            case 1:
                if (Input.GetKeyDown(KeyCode.S))
                {
                    PlayerArrowpos++;
                    if (PlayerArrowpos >= 3) { PlayerArrowpos = 0; }
                }

                if (Input.GetKeyDown(KeyCode.W))
                {
                    PlayerArrowpos--;
                    if (PlayerArrowpos <= -1) { PlayerArrowpos = 2; }
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    switch (PlayerArrowpos)
                    {
                        case 0:
                            PlayerBattlefaze = 1;
                            break;
                        case 1:
                            PlayerBattlefaze = 2;
                            break;
                        case 2:
                            PlayerBattlefaze = 3;
                            break;
                    }
                }

                if (PlayerHP > 0)
                {
                    switch (PlayerBattlefaze)
                    {
                        case 0:
                            EnemyBattletextComponent.text = "";
                            switch (PlayerArrowpos)
                            {
                                case 0:
                                    PlayerWindowtextComponent.text = "���U��\n�@��\n�@���@";
                                    break;
                                case 1:
                                    PlayerWindowtextComponent.text = "�@�U��\n����\n�@���@";
                                    break;
                                case 2:
                                    PlayerWindowtextComponent.text = "�@�U��\n�@��\n�����@";
                                    break;
                            }
                            break;
                        case 1:
                            PlayerWindowtextComponent.text = "�v���C���[��\n�U��!";
                            PlayerBattleTime++;
                            if (PlayerBattleTime > 60)
                            {
                                EnemyHP -= 3;
                                EnemyHPtextComponent.text = "EnemyHP : " + EnemyHP;
                                PlayerArrowpos = 0;
                                PlayerBattleTime = 0;
                                PlayerBattlefaze = 4;
                                EnemyBattlefaze = 1;
                            }
                            break;
                        case 2:
                            PlayerWindowtextComponent.text = "�v���C���[��\n�񕜂���!";
                            PlayerBattleTime++;
                            if (PlayerBattleTime > 60)
                            {
                                PlayerHP += 20;
                                PlayerHPtextComponent.text = "PlayerHP : " + PlayerHP;
                                PlayerArrowpos = 0;
                                PlayerBattleTime = 0;
                                PlayerBattlefaze = 4;
                                EnemyBattlefaze = 2;
                            }
                            break;
                        case 3:
                            PlayerWindowtextComponent.text = "�v���C���[��\n���@���g����!";
                            PlayerBattleTime++;
                            if (PlayerBattleTime > 60)
                            {
                                EnemyHP -= 5;
                                EnemyHPtextComponent.text = "EnemyHP : " + EnemyHP;
                                PlayerArrowpos = 0;
                                PlayerBattleTime = 0;
                                PlayerBattlefaze = 4;
                                EnemyBattlefaze = 3;
                            }
                            break;
                    }
                }

                if (EnemyHP > 0)
                {
                    switch (EnemyBattlefaze)
                    {
                        case 1:
                            EnemyBattletextComponent.text = "�G�l�~�[�̍U��!";
                            EnemyBattleTime++;
                            if (EnemyBattleTime > 60)
                            {
                                PlayerHP -= 5;
                                PlayerHPtextComponent.text = "PlayerHP : " + PlayerHP;
                                EnemyBattlefaze = 0;
                                EnemyBattleTime = 0;
                                PlayerBattlefaze = 0;
                            }
                            break;
                        case 2:
                            EnemyBattletextComponent.text = "�G�l�~�[�̍U��!";
                            EnemyBattleTime++;
                            if (EnemyBattleTime > 60)
                            {
                                PlayerHP -= 10;
                                PlayerHPtextComponent.text = "PlayerHP : " + PlayerHP;
                                EnemyBattlefaze = 0;
                                EnemyBattleTime = 0;
                                PlayerBattlefaze = 0;
                            }
                            break;
                        case 3:
                            EnemyBattletextComponent.text = "�G�l�~�[�̍U��!";
                            EnemyBattleTime++;
                            if (EnemyBattleTime > 60)
                            {
                                PlayerHP -= 15;
                                PlayerHPtextComponent.text = "PlayerHP : " + PlayerHP;
                                EnemyBattlefaze = 0;
                                EnemyBattleTime = 0;
                                PlayerBattlefaze = 0;
                            }
                            break;
                    }
                }
                else
                {
                    SceneFlag = 2;
                    SceneManager.LoadScene("ClearScene");
                }
                if (PlayerHP <= 0)
                {
                    SceneFlag = 2;
                    SceneManager.LoadScene("GameOverScene");
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneFlag = 0;
                    SceneManager.LoadScene("TitleScene");
                }
                break;
        }

    }
}
