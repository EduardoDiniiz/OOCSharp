using CourseOOCSharp.Entities.Enums;
using System.Collections.Generic;

namespace CourseOOCSharp.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker ()
        {

        }

        public Worker (string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        
        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            List<HourContract> contracts = Contracts.FindAll(x => x.Date.Year == year && x.Date.Month == month);
            if(contracts.Count > 0)
            {
                foreach(HourContract contract in contracts)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
