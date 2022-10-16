using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Refactoring.collections;
using Refactoring.entities;

namespace Refactoring.db


{
    public class DbClientClientMock : IDbClient


    {
        #region Fileds
        private readonly List<Student> _students;
        private readonly List<Worker> _workers;
        #endregion

        #region Constructor

        public DbClientClientMock()
        {
            this._workers = ReadWorkers();
            this._students = ReadStudents();
        }
        #endregion

        #region Methods
        private List<Student> ReadStudents()
        {
            string fileName = "C:/Users/Ajdar/RiderProjects/Refactoring/Refactoring/db/students.json";
            string jsonString = File.ReadAllText(fileName);
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            return students;
        }

        private List<Worker> ReadWorkers()
        {
            string fileName = "C:/Users/Ajdar/RiderProjects/Refactoring/Refactoring/db/workers.json";
            string jsonString = File.ReadAllText(fileName);
            List<Worker> workers = JsonSerializer.Deserialize<List<Worker>>(jsonString);
            return workers;
        }

        public HumanContainer<Human> InitContainer1()
        {
            return new HumanContainer<Human>
            {
                _students[0], _students[1], _workers[0], _workers[1]
            };
        }

        public HumanContainer<Human> InitContainer2()
        {
            return new HumanContainer<Human>
            {
                _students[2], _students[3], _students[4], _workers[2]
            };
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public List<Worker> GetAllWorkers()
        {
            return _workers;
        }
        
        #endregion
    }
}