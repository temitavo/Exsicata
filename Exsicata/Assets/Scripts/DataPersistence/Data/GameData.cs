using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string plantInPot01;
    public string plantInPot02;
    public string plantInPot03;


    public int quantiGirassol;
    public int quantiLirio;
    public int quantiOrquidea;
    public int quantiSamambaia;


    public int plantInPot01Stage;
    public int plantInPot02Stage;
    public int plantInPot03Stage;

    public int panquecasAmount;

    public string timeStart01;
    public string timeEnd01;
    public string timeStart02;
    public string timeEnd02;
    public string timeStart03;
    public string timeEnd03;

    public string INKVariables;

    //quando não tiver save file to load porque ainda não foi iniciado o jogo
    //esses são os valores que serão utilizados
    public GameData(){
        this.panquecasAmount = 0;

        this.plantInPot01 = "";
        this.plantInPot02 = "";
        this.plantInPot03 = "";

        this.quantiGirassol = 0;
        this.quantiLirio = 0;
        this.quantiOrquidea = 0;
        this.quantiSamambaia = 0;

        this.plantInPot01Stage = 0;
        this.plantInPot02Stage = 0;
        this.plantInPot03Stage = 0;

        this.timeStart01 = "";
        this.timeEnd01 = "";

        this.timeStart02 = "";
        this.timeEnd02 = "";

        this.timeStart03 = "";
        this.timeEnd03 = "";

        this.INKVariables = "";
    }

}
