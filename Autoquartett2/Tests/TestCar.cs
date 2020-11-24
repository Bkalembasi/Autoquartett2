using System;
using System.Collections.Generic;
using System.Text;

namespace Autoquartett2.Tests
{
    public class TestCar
    {
        public static void Main(string[] args)
        {
            Car volkswagenGolf = new Car();
            volkswagenGolf.SetBrand("Volkswagen");
            volkswagenGolf.SetModel("Golf V");
            volkswagenGolf.SetCarClass("Kompaktklasse");
            volkswagenGolf.SetAcceleration(14.7);
            volkswagenGolf.SetCcm(1390);
            volkswagenGolf.SetConsumption(6.8);
            volkswagenGolf.SetKmPerH(164);
            volkswagenGolf.SetPiston(4);
            volkswagenGolf.SetPs(75);
            Console.WriteLine(volkswagenGolf.ToString());

            Car mazdaRX8 = new Car();
            mazdaRX8.SetBrand("Mazda");
            mazdaRX8.SetModel("RX-8");
            mazdaRX8.SetCarClass("Sportwagen");
            mazdaRX8.SetAcceleration(6.4);
            mazdaRX8.SetCcm(1308);
            mazdaRX8.SetConsumption(11.4);
            mazdaRX8.SetKmPerH(235);
            mazdaRX8.SetPiston(2);
            mazdaRX8.SetPs(231);
            Console.WriteLine(mazdaRX8.ToString());


            double[] werte = new double[2];
            werte[0] = volkswagenGolf.GetCcm();
            werte[1] = mazdaRX8.GetCcm();

            bool test = true;

            Console.WriteLine(Car.Comparison(werte, test));


        }
    }
}