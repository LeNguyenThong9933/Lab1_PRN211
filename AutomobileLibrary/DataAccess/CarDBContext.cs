using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BussinessObject;

namespace AutomobileLibrary.DataAccess
{
    internal class CarDBContext
    {
        //Initialize list
        private static List<Car> CarList = new List<Car>()
        {
            new Car{CarID = 1, CarName = "CRV", Manufacturer = "Honda", Price = 30000, ReleaseYear = 2021},
            new Car{CarID = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price = 15000, ReleaseYear = 2020}
        };//end list

        //using singleton pattern
        private static CarDBContext instance = null;
        private static readonly object instancelock = new object();
        private CarDBContext() { }  
        public static CarDBContext Instance 
        {
            get
            { 
                lock (instancelock) 
                {
                    if (instance == null) 
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }


    public List<Car> GetCarList => CarList;
    public Car GetCarByID(int carID) 
    {
        //using LINQ to object
        Car car = CarList.SingleOrDefault(pro => pro.CarID == carID);
        return car;
    }
    
    //add new
    public void AddNew(Car car) 
        {
            Car pro = GetCarByID(car.CarID);
            if (pro == null)
            {
                CarList.Add(car);

            }
            else {
                throw new Exception("Car is already exists.");
            }
        }
        //update
    public void Update(Car car) 
        {
        Car c = GetCarByID(car.CarID);
        if (c != null) { 
            var index = CarList.IndexOf(c);
            CarList[index] = car;
        }
        else 
            {
                throw new Exception("Car does not already exists.");
            }
        }
        //remove
        public void Remove(int carID) 
        {
            Car p = GetCarByID(carID);
            if (p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car does not already exists.");
            }
        }
        
    }//end class
}//end namespace
