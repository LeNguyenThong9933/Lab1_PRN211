using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomobileLibrary.BussinessObject;

namespace AutomobileLibrary.Repository
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCarByID(int CarID);
        void InsertCar(Car car);
        void DeleteCar(int CarID);
        void UpdateCar(Car car);
    }
}
