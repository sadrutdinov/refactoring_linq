using System.Collections.Generic;
using Refactoring.collections;
using Refactoring.entities;

namespace Refactoring.db
{
    public interface IDbClient
    {
        HumanContainer<Human> InitContainer1();
        HumanContainer<Human> InitContainer2();
        List<Student> GetAllStudents();
        List<Worker> GetAllWorkers();
    }
}