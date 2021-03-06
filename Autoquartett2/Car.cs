﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Autoquartett2
{
    public class Car        
    {
        [JsonProperty]
        private string brand;
        [JsonProperty]
        private string model;
        [JsonProperty]
        private string carClass;
        [JsonProperty]
        private int kmPerH;
        [JsonProperty]
        private int ps;
        [JsonProperty]
        private double consumption;
        [JsonProperty]
        private int ccm;
        [JsonProperty]
        private int piston;
        [JsonProperty]
        private double acceleration;


        public void SetBrand(string ParamBrand)
        {
            this.brand = ParamBrand;
        }

        public string GetBrand()
        {
            return this.brand;
        }

        public void SetModel(string ParamModel)
        {
            this.model = ParamModel;
        }

        public string GetModel()
        {
            return this.model;
        }

        public void SetCarClass(string ParamCarClass)
        {
            this.carClass = ParamCarClass;
        }

        public string GetCarClass()
        {
            return this.carClass;
        }

        public void SetKmPerH(int ParamKmPerH)
        {
            this.kmPerH = ParamKmPerH;
        }

        public int GetKmPerH()
        {
            return (this.kmPerH);
        }

        public void SetPs(int ParamPs)
        {
            this.ps = ParamPs;
        }

        public int GetPs()
        {
            return (this.ps);
        }

        public void SetConsumption(double ParamConsumption)
        {
            this.consumption = ParamConsumption;
        }

        public double GetConsumption()
        {
            return (this.consumption);
        }

        public void SetCcm(int ParamCcm)
        {
            this.ccm = ParamCcm;
        }

        public int GetCcm()
        {
            return (this.ccm);
        }

        public void SetPiston(int ParamPiston)
        {
            this.piston = ParamPiston;
        }

        public int GetPiston()
        {
            return (this.piston);
        }

        public void SetAcceleration(double ParamAcceleration)
        {
            this.acceleration = ParamAcceleration;
        }

        public double GetAcceleration()
        {
            return (this.acceleration);
        }

        public string[] GetCardInformation()
        {
            string[] carInfo = new string[9];
            carInfo[0] = "Marke: " + GetBrand();
            carInfo[1] = "Modell: " + GetModel();
            carInfo[2] = "Klasse: " + GetCarClass();
            carInfo[3] = "(1) Beschleunigung: " + GetAcceleration();
            carInfo[4] = "(2) Hubraum: " + GetCcm();
            carInfo[5] = "(3) Verbrauch: " + GetConsumption();
            carInfo[6] = "(4) Hm/H: " + GetKmPerH();
            carInfo[7] = "(5) PS: " + GetPs();
            carInfo[8] = "(6) Zylinder: " + GetPiston();

            return carInfo;
        }

        public static int Comparison(double[] values, bool higherNumber)
        {
            int playerIndex = 0;
            double tempNumber = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (higherNumber)
                {
                    if (tempNumber < values[i])
                    {
                        tempNumber = values[i];
                        playerIndex = i;
                    }
                }
                else 
                {
                    if (tempNumber > values[i])
                    {
                        tempNumber = values[i];
                        playerIndex = i;
                    }
                }
            }

            return playerIndex;
        }

        public override string ToString()
        {
            string ausgabe;

            ausgabe = String.Format("Marke: {0} \n" +
                                    "Modell: {1} \n" +
                                    "Klasse: {2} \n" +
                                    "Km/h: {3} \n" +
                                    "Ps: {4} \n" +
                                    "Verbrauch: {5} \n" +
                                    "Hubraum: {6} \n" +
                                    "Anzahl zylinder: {7} \n" +
                                    "Beschleunigung: {8} \n\n",
                GetBrand(), GetModel(),
                GetCarClass(), GetKmPerH(),
                GetPs(), GetConsumption(),
                GetCcm(), GetPiston(),
                GetAcceleration());
            return ausgabe;
        }
    }
}
