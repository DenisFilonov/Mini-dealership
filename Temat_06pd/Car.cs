using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Temat_06pd
{
    internal class Car
    {
        //===========================================================Fields
        private string _name;
        private string _model;
        private string _typeofveh;
        private string _gearbox;
        private string _color;

        private float _price;
        private int _maxspeed; // float никак не может быть, спидометр показывает всегда ц/значения
        private int _productionyear;
        private string _carclass;
        /*
        А: мини-автомобили;
        B: небольшие городские автомобили;
        C: низший средний класс или гольф-класс;
        D: полноценный средний класс;
        E: представительский или бизнес-класс;
        F: роскошные и люксовые автомобили;
        J: внедорожники;
        M: многоцелевые автомобили, минивэны;
        */
        //===========================================================Constructors

        public Car()
        {
            _name = "Renault";
            _model = "Fluence";
            _typeofveh = "Sedan";
            _gearbox = "Automatic transmission";
            _color = "Black";
            _price = 7500;
            _maxspeed = 270;
            _productionyear = 2015;
            _carclass = "C";
        }
        public Car(string name, string model, string typeofveh, string gearbox, string color, float price, int maxspeed, int productionyear, string carclass)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new Exception("The name field can't be empty!");
            if (String.IsNullOrWhiteSpace(model)) throw new Exception("The model field can't be empty!");
            if (String.IsNullOrWhiteSpace(typeofveh)) throw new Exception("The type of vehicle field can't be empty!");
            if (String.IsNullOrWhiteSpace(gearbox)) throw new Exception("The gearbox field can't be empty!");
            if (String.IsNullOrWhiteSpace(color)) throw new Exception("The color field can't be empty!");
            if (price == 0 || price < 0) throw new Exception("The price field can't be null, zero or less than zero!");
            if (maxspeed == 0 || maxspeed < 0 || maxspeed > 500) throw new Exception("The maxspeed field can't be zero or less than zero or more than five hundred!");
            if (productionyear < 1999 || productionyear > 2999 || productionyear == 0 || productionyear < 0) throw new Exception("The production year field set wrong, check input data!");
            if (String.IsNullOrWhiteSpace(carclass) || carclass.Length > 1) throw new Exception("The carclass field can't be empty, or more than one character!");

            _name = name;
            _model = model;
            _typeofveh = typeofveh;
            _gearbox = gearbox;
            _color = color;
            _price = price;
            _maxspeed = maxspeed;
            _productionyear = productionyear;
            _carclass = carclass;
        }

        public Car(Car obj)
        {
            _name = obj._name;
            _model = obj._model;
            _typeofveh = obj._typeofveh;
            _gearbox = obj._gearbox;
            _color = obj._color;
            _price = obj._price;
            _maxspeed = obj._maxspeed;
            _productionyear = obj._productionyear;
            _carclass = obj._carclass;
        }
        //==========================================================Accessors=Setters
        public void SetName(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) throw new Exception("The name field can't be empty!"); // А чё б и не воткнуть эксепшены? ООП же.
            _name = name;
        }
        public void SetModel(string model)
        {
            if (String.IsNullOrWhiteSpace(model)) throw new Exception("The model field can't be empty!");
            _model = model;
        }
        public void SetTypeOfVeh(string typeofveh)
        {
            if (String.IsNullOrWhiteSpace(typeofveh)) throw new Exception("The type of vehicle field can't be empty!");
            if (IsCorrectTypeOfVeh())
            {
                _typeofveh = typeofveh;
            }
            else
            {
                Console.WriteLine("\nUndefinied type of car! Please, check the input data.");
                TypesOfTransport();
            }
        }
        public void SetGearBox(string gearbox)
        {
            if (String.IsNullOrWhiteSpace(gearbox)) throw new Exception("The gearbox field can't be empty!");
            if (IsCorrectTypeOfTransmission())
            {
                _gearbox = gearbox;
            }
            else
            {
                Console.WriteLine("\nUndefinied car transmission! Please, check the input data.");
                GearBoxes();
            }

        }
        public void SetColor(string color)
        {
            if (String.IsNullOrWhiteSpace(color)) throw new Exception("The color field can't be empty!");
            _color = color;
        }
        public void SetPrice(float price)
        {
            if (price == 0 || price < 0) throw new Exception("The price field can't be null, zero or less than zero!");
            _price = price;
        }
        public void SetMaxSpeed(int maxspeed)
        {
            if (maxspeed == 0 || maxspeed < 0 || maxspeed > 500) throw new Exception("The maxspeed field can't be zero or less than zero or more than five hundred!");
            _maxspeed = maxspeed;
        }
        public void SetProductionYear(int productionyear)
        {
            if (productionyear < 1999 || productionyear > 2999 || productionyear == 0 || productionyear < 0) throw new Exception("The production year field set wrong, check input data!");
            _productionyear = productionyear;
        }
        public void SetCarClass(string carclass)
        {
            if (String.IsNullOrWhiteSpace(carclass) || carclass.Length > 1) throw new Exception("The carclass field can't be empty, or more than one character!");

            if (IsRightCarClass())
            {
                _carclass = carclass;
            }
            else
            {
                Console.WriteLine("\nUndefinied car class! Please, check the input data.");
                CarClasses();
            }
        }
        //==========================================================Accessors=Getters
        public string GetName()
        {
            return _name;
        }
        public string GetModel()
        {
            return _model;
        }
        public string GetTypeOfVeh()
        {
            return _typeofveh;
        }
        public string GetGearBox()
        {
            return _gearbox;
        }
        public string GetColor()
        {
            return _color;
        }
        public float GetPrice()
        {
            return _price;
        }
        public int GetMaxSpeed()
        {
            return _maxspeed;
        }
        public int GetProductionYear()
        {
            return _productionyear;
        }
        public string GetCarClass()
        {
            return _carclass;
        }
        //===========================================================Additional
        public void Show()
        {
            Console.WriteLine("Name: {0}\nModel: {1}\nType of vehicle: {2}\nGear box: {3}\nColor: {4}\nPrice in USD: {5}\nMaximal speed: {6}\nProduction year: {7}\nCar class: {8}",
                _name, _model, _typeofveh, _gearbox, _color, _price, _maxspeed, _productionyear, _carclass);
        }
        void TypesOfTransport()
        {
            Console.WriteLine("\n\tExisting types of cars:\n1. Sedan.\n2. Universal.\n3. Hatchback.\n4. Minivan.\n5. Crossover.\n6. Coupe.\n7. Cabriolet.\n8. Pickup");
        }
        public void GearBoxes()
        {
            Console.WriteLine("\n\tExisting types of gearboxes:\n1. Manual Transmission.\n2. Intelligent manual transmission(IMT).\n3. Automated manual transmission(AMT).\n4. Automatic transmission(AT).\n5. Continuously variable transmission(CVT).\n6. Semi - automatic transmission.\n7. Dual - clutch transmission.\n8. Sequential transmission.\n");
        }

        public void CarClasses()
        {
            Console.WriteLine("Car classes: \nA: mini cars;\nB: small city cars;\nC: lower middle class or golf class;\nD: full-fledged middle class;\nE: executive or business class;\nF: luxury and luxury cars;\nJ: SUVs;\nM: multi-purpose vehicles, minivans;");
        }
        public bool IsCorrectTypeOfVeh()
        {
            if (_typeofveh == "Sedan" || _typeofveh == "Universal" || _typeofveh == "Hatchback" || _typeofveh == "Minivan" || _typeofveh == "Crossover" ||
                _typeofveh == "Coupe" || _typeofveh == "Cabriolet" || _typeofveh == "Pickup" || _typeofveh == "NONE")
            {
                return true;
            }

            else return false;
        }
        public bool IsCorrectTypeOfTransmission()
        {
            if (_gearbox == "Manual transmission" || _gearbox == "Intelligent manual transmission" || _gearbox == "Automated manual" || _gearbox == "Automatic transmission" ||
                _gearbox == "Continuously variable transmission" || _gearbox == "Semi-automatic transmission" || _gearbox == "Dual-clutch transmission" || _gearbox == "Sequential transmission")
            {
                return true;
            }

            else return false;
        }

        public bool IsRightCarClass()
        {
            /*
            А: мини-автомобили;
            B: небольшие городские автомобили;
            C: низший средний класс или гольф-класс;
            D: полноценный средний класс;
            E: представительский или бизнес-класс;
            F: роскошные и люксовые автомобили;
            J: внедорожники;
            M: многоцелевые автомобили, минивэны;
            */

            if (_carclass == "A" || _carclass == "B" || _carclass == "C" || _carclass == "D" || _carclass == "E"
                || _carclass == "F" || _carclass == "M" || _carclass == "N" || _carclass == "J")
            {
                return true;
            }
            else return false;
        }

        public string Type()
        {
            return "Car";
        }
        public string ToString()
        {
            return Type() + "+" + _name + "+" + _model + "+" + _typeofveh + "+" + _gearbox + "+"
                + _color + "+" + _price.ToString() + "+" + _maxspeed.ToString() + "+" + _productionyear.ToString() + "+" + _carclass + "+";
        }
    }
}
