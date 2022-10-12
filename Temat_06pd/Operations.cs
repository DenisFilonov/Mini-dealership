using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Temat_06pd
{
    /*
      1.	Разработать класс Car, описывающий автомобиль 
      2.	Класс должен включать конструктор с параметрами, конструктор без параметров, поля, необходимые для описания автомобиля.
      3.	Создать класс, который будет содержать массив экземпляров класса Car.
      4.	Создать методы сортировки автомобилей по названию и по цене, методы для работы с данными (добавление, удаление), продемонстрировать работу этих методов.
    */
    internal class Operations
    {
        //Car[] car = new Car[0];
        List<Car> cars = new List<Car>();
        public void AddCar(Car obj)
        {
            //Array.Resize(ref car, car.Length + 1);
            //car[car.Length - 1] = obj;
            cars.Add(obj);
        }

        public void DelCar(int id)
        {
            cars.RemoveAt(id - 1);
        }
        public int SortByPriceAscending(Car obj1, Car obj2)
        {

            return obj2.GetPrice().CompareTo(obj1.GetPrice()); // если поменять obj2 c obj1 сортировка будет от меньшего к большему
        }
        public int SortByNameAscending(Car obj1, Car obj2)
        {

            return obj2.GetName().CompareTo(obj1.GetName()); // если поменять obj2 c obj1 сортировка будет от меньшего значения к большему значению
        }
        public void SortCarsByPrice()
        {
            cars.Sort(SortByPriceAscending);
        }
        public void SortCarsByName()
        {
            cars.Sort(SortByNameAscending);
        }
        public void ShowCars()
        {
            for (int i = 0; i < cars.Count; i++) // for, не foreach для использовании индексации
            {
                Console.WriteLine($"\tCar # {i + 1}"); // Красота, показать индексацию для пользователя
                cars[i].Show(); // Вывод инфы
                Console.WriteLine(); // Отступ, красота
            }
        }

    }
}
