using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.collections;
using Refactoring.entities;

namespace Refactoring.processors
{
    public class Processor
    {
        #region Methods

        public void PrintOrderBy(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: OrderBy Height, ThenBy Weight");
            var orderRes = container.OrderBy(h => h.Height).ThenBy(h => h.Weight);
            foreach (var human in orderRes)
                Console.WriteLine(human);
        }

        public void PrintWhere(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: Where");
            var whereRes = container.Where(h =>
                (h.Height > 170 && h.Weight >= 58) || h.FullName.StartsWith("L"));
            foreach (var human in whereRes)
                Console.WriteLine(human.ToString());
        }

        public void PrintSelect(HumanContainer<Human> container)
        {
            //select
            Console.WriteLine("\nLinqTo objects: Select");
            var selectRes = container.Select((h, i) => new
            {
                Index = i + 1,
                h.FullName
            });

            foreach (var el in selectRes)
            {
                Console.WriteLine(el);
            }
        }

        public void PrintSelectMany(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: SelectMany");
            var selectManyRes = container.SelectMany(h => h.FullName.Split(' '));
            foreach (var el in selectManyRes)
                Console.WriteLine(el);
        }


        public void PrintSkip(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: Skip");
            var skipRes = container.Skip(2);
            foreach (var human in skipRes)
            {
                Console.WriteLine(human);
            }
        }

        public void PrintSkipWhile(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: SkipWhile");
            var skipWhileRes = container.SkipWhile(h => h.Height < 190);
            foreach (var human in skipWhileRes)
            {
                Console.WriteLine(human);
            }
        }

        public void PrintTake(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: Take");
            var takeRes = container.Take(2);
            foreach (var human in takeRes)
            {
                Console.WriteLine(human);
            }
        }

        public void PrintTakeWhile(HumanContainer<Human> container)
        {
            //TakeWhile
            Console.WriteLine("\nLinqTo objects: TakeWhile");
            var takeWhileRes = container.TakeWhile(h => h.Height < 190);
            foreach (var human in takeWhileRes)
            {
                Console.WriteLine(human);
            }
        }

        public void PrintConcat(HumanContainer<Human> container, HumanContainer<Human> other)
        {
            Console.WriteLine("\nLinqTo objects: Concat");
            var concatRes = container.Concat(other);
            foreach (var human in concatRes)
            {
                Console.WriteLine(human);
            }
        }


        public void PrintGroupBy(HumanContainer<Human> container)
        {
            // concatRes => container

            Console.WriteLine("\nLinqTo objects: GroupBy");
            var groupByRes = container.Where(h => h is Student).GroupBy(h =>
                ((Student)h).University);
            foreach (var group in groupByRes)
            {
                Console.WriteLine($"Group: {group.Key}, Count: {group.Count()}");
                foreach (var human in group) Console.WriteLine(human);
            }
        }

        public void PrintFirst(HumanContainer<Human> container)
        {
            // concatRes => container
            Console.WriteLine("\nLinqTo objects: First");
            var firstRes = container.First(h => h.FullName.Length > 12);
            Console.WriteLine(firstRes);
        }

        public void PrintFirstOrDefault(HumanContainer<Human> container)
        {
            //FirstOrDefault
            Console.WriteLine("\nLinqTo objects: FirstOrDefault");
            var firstOrDefRes = container.FirstOrDefault(h => h.FullName.Length > 14);
            if (firstOrDefRes != null)
                Console.WriteLine();
        }

        public void PrintDefaultIfEmpty(HumanContainer<Human> container)
        {
            //DefaultIfEmpty
            Console.WriteLine("\nLinqTo objects: DefaultIfEmpty");
            var defaultIfEmptyRes = container.Where(c => c.FirstName == "Eleanor")
                .DefaultIfEmpty(new Human
                {
                    FirstName = "Eleanor",
                    LastName = "Fuller"
                })
                .First();

            Console.WriteLine(defaultIfEmptyRes);
        }


        public void PrintMin(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: Min");
            var minRes = container.Min(h => h.Weight);
            Console.WriteLine(minRes);
        }


        public void PrintMax(HumanContainer<Human> container)
        {
            Console.WriteLine("\nLinqTo objects: Max");
            var maxRes = container.Max(h => h.Height);
            Console.WriteLine(maxRes);
        }

        public void PrintJoin(HumanContainer<Human> container, HumanContainer<Human> other)
        {
            //Join
            Console.WriteLine("\nLinqTo objects: Join");
            var joinRes = container.Join(other, o => o.Height, i => i.Height,
                (o, i) => new Human
                {
                    FirstName = o.FirstName + " " + i.FirstName,
                    LastName = o.LastName + " " + i.LastName,
                    Height = o.Height,
                    Weight = (o.Weight + i.Weight) / 2
                });
            foreach (var human in joinRes)
                Console.WriteLine(human);
        }

        public void PrintGroupJoin(HumanContainer<Human> container, HumanContainer<Human> other)
        {
            Console.WriteLine("\nLinqTo objects: GroupJoin");
            var groupJoinRes = container.GroupJoin(other, o => o.Height, i => i.Height,
                (o, i) => new
                {
                    FullName = $"{o.FirstName} {o.LastName}",
                    Count = i.Count(),
                    TotalWeight = i.Sum(s => s.Weight)
                });
            foreach (var human in groupJoinRes)
            {
                Console.WriteLine($"{human.FullName}: Count = {human.Count}, TotalWeight: {human.TotalWeight}");
            }
        }

        public void PrintAllAndAny(List<HumanContainer<Human>> list)
        {
            Console.WriteLine("\nLinqTo objects: All/Any");
            var allAnyRes = list.First(c => c.All(h => h.Height > 160)
                                            && c.Any(h => h is Worker))
                .Select(h => h.FirstName)
                .OrderByDescending(s => s);
            foreach (var name in allAnyRes)
                Console.WriteLine(name);
        }

        public void PrintContains(List<HumanContainer<Human>> list, Human human)
        {
            Console.WriteLine("\nLinqTo objects: Contains");
            var containsRes = list.Where(c => c.Contains(human))
                .SelectMany(c => c.SelectMany(h => h.FullName.Split(' ')))
                .Distinct()
                .OrderBy(s => s)
                .ToList();
            foreach (var name in containsRes)
                Console.WriteLine(name);
        }

        public void PrintSearchBySize(LinkedList<HumanContainer<Human>> list, Int32 size)
        {
            Console.WriteLine($"\nLinqTo objects: Search by size = {size}");
            var result = list.Where(c => c.Count == size);

            int i = 1;
            foreach (var collection in result)
            {
                Console.WriteLine($"collection_{i} size: {collection.Count}");
                foreach (var human in collection)
                {
                    Console.WriteLine(human);
                }

                Console.WriteLine();
                i++;
            }
        }

        public void PrintMaxCollection(LinkedList<HumanContainer<Human>> list)
        {
            Console.WriteLine($"\nLinqTo objects: Max collection");
            var maxCount = list.Max(c => c.Count);
            var maxCollection = list.First(c => c.Count == maxCount);

            Console.WriteLine($"maxCollection size: {maxCollection.Count}");
            foreach (var human in maxCollection)
            {
                Console.WriteLine(human);
            }
        }

        public void PrintMinCollection(LinkedList<HumanContainer<Human>> list)
        {
            Console.WriteLine($"\nLinqTo objects: Min collection");
            var minCount = list.Min(c => c.Count);
            var minCollection = list.First(c => c.Count == minCount);

            Console.WriteLine($"minCollection size: {minCollection.Count}");
            foreach (var human in minCollection)
            {
                Console.WriteLine(human);
            }
        }

        #endregion
    }
}