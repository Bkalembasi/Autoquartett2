using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Autoquartett2
{
    class Car        
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


        public void setBrand(string ParamBrand)
        {
            this.brand = ParamBrand;
        }

        public string getBrand()
        {
            return this.brand;
        }

        public void setModel(string ParamModel)
        {
            this.model = ParamModel;
        }

        public string getModel()
        {
            return this.model;
        }

        public void setCarClass(string ParamCarClass)
        {
            this.carClass = ParamCarClass;
        }

        public string getCarClass()
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

        public void GetCardInformation()
        {
            //TODO
            Console.WriteLine(this.GetAcceleration());
            Console.WriteLine(this.GetCcm());
            Console.WriteLine(this.GetConsumption());
            Console.WriteLine(this.GetKmPerH());
            Console.WriteLine(this.GetPs());
            Console.WriteLine(this.GetPiston());
        }

        public double Comparison(double[] values, bool higherNumber)
        {
            double tempHighest = 0;
            double tempLowest = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > tempHighest)
                {
                    tempHighest = values[i];
                }
                else if (values[i] < tempLowest)
                {
                    tempLowest = values[i];
                }
            }

            if (higherNumber)
            {
                return tempHighest;
            }
            else
            {
                return tempLowest;
            }
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
                getBrand(), getModel(),
                getCarClass(), GetKmPerH(),
                GetPs(), GetConsumption(),
                GetCcm(), GetPiston(),
                GetAcceleration());
            return ausgabe;
        }
    }
}
