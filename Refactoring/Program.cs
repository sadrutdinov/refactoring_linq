using System;
using System.Collections.Generic;
using Refactoring.collections;
using Refactoring.db;
using Refactoring.entities;
using Refactoring.processors;

namespace Refactoring

{
    class Program
    {
        static void Main()
        {
            try
            {
                IDbClient dbClient = new DbClientClientMock();
                Processor processor = new Processor();

                var container1 = dbClient.InitContainer1();
                var container2 = dbClient.InitContainer2();

                RunProcessorMethods(processor, container1, container2, dbClient);

                RunTaskByOptionNo1(processor, container1, container2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RunProcessorMethods(Processor processor, HumanContainer<Human> container1,
            HumanContainer<Human> container2, IDbClient dbClient)
        {
            var students = dbClient.GetAllStudents();
            var workers = dbClient.GetAllWorkers();

            container1.Remove(workers[1]);
            container1.Remove(students[0]);
            container2.Sort();

            Console.WriteLine("container1: ");
            foreach (var human in container1)
            {
                Console.WriteLine(human.ToString());
            }

            Console.WriteLine("container2: ");
            foreach (var human in container2)
            {
                Console.WriteLine(human.ToString());
            }

            var listOfContainers = new List<HumanContainer<Human>>();
            listOfContainers.Add(container1);
            listOfContainers.Add(container2);

            processor.PrintOrderBy(container1);

            processor.PrintWhere(container1);

            processor.PrintSelect(container1);

            processor.PrintSelectMany(container1);

            processor.PrintSkip(container1);

            processor.PrintSkipWhile(container1);

            processor.PrintTake(container1);

            processor.PrintTakeWhile(container1);

            processor.PrintConcat(container1, container2);

            processor.PrintGroupBy(container2);

            processor.PrintFirst(container1);

            processor.PrintFirstOrDefault(container1);

            processor.PrintDefaultIfEmpty(container1);

            processor.PrintMin(container1);

            processor.PrintMax(container1);

            processor.PrintJoin(container1, container2);

            processor.PrintGroupJoin(container1, container2);

            processor.PrintAllAndAny(listOfContainers);

            processor.PrintContains(listOfContainers, workers[0]);
        }

        private static void RunTaskByOptionNo1(Processor processor, HumanContainer<Human> container1,
            HumanContainer<Human> container2)
        {
            // создать массив объектов CollectionType, запросы – найти коллекции размера n;
            // найти максимальную и минимальную коллекцию в массиве по количеству элементов.
            //     Обобщенная коллекция – LinkedList<T>

            var listOfContainers = new LinkedList<HumanContainer<Human>>();
            listOfContainers.AddLast(container1);
            listOfContainers.AddLast(container2);

            processor.PrintSearchBySize(listOfContainers, 4);
            processor.PrintSearchBySize(listOfContainers, 2);

            processor.PrintMaxCollection(listOfContainers);
            processor.PrintMinCollection(listOfContainers);
        }
    }
}