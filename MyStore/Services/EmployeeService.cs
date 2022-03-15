using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{

    public interface IEmployeeService
    {
        EmployeeModel AddEmployee(EmployeeModel newEmployee);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<EmployeeModel> GetAllEmployees();
        EmployeeModel GetById(int id);
        void UpdateEmployee(EmployeeModel model);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            //take domain objects
            var allEmployees = employeeRepository.GetAll().ToList();//List<Employee>
                                                                    //transform domain objects from List<Employee> -> List<EmployeeModel>
            var employeeModels = mapper.Map<IEnumerable<EmployeeModel>>(allEmployees);

            return employeeModels;
            //for (int i = 0; i < allEmployees.Count(); i++)
            //{
            //    var employeeModel = new EmployeeModel();
            //    employeeModel.Categoryid = allEmployees[i].Categoryid;
            //    employeeModel.Employeeid = allEmployees[i].Employeeid;
            //    employeeModel.Employeename = allEmployees[i].Employeename;
            //    employeeModel.Unitprice = allEmployees[i].Unitprice;
            //    employeeModel.Discontinued = allEmployees[i].Discontinued;
            //}

            //1 la 1
            //var source = new Employee();
            //var destination = new EmployeeModel();

            //destination.Categoryid = source.Categoryid;
            //destination.Discontinued = source.Discontinued;
            //destination.Employeeid = source.Employeeid;
            //destination.Employeename = source.Employeename;
            //destination.Supplierid = source.Supplierid;
            //destination.Unitprice = source.Unitprice;



        }

        public EmployeeModel GetById(int id)
        {
            var employeeToGet = employeeRepository.GetById(id);
            return mapper.Map<EmployeeModel>(employeeToGet);
        }
        public bool Exists(int id)
        {
            return employeeRepository.Exists(id);
        }
        public EmployeeModel AddEmployee(EmployeeModel newEmployee)
        {
            //Employee addedEmployee = mapper.Map<Employee>(newEmployee);
            //return employeeRepository.Add(addedEmployee);

            Employee employeeToAdd = mapper.Map<Employee>(newEmployee);
            employeeRepository.Add(employeeToAdd);
            //var addedEmployee = employeeRepository.Add(employeeToAdd);
            //newEmployee = mapper.Map<EmployeeModel>(addedEmployee);
            return newEmployee;
        }
        public void UpdateEmployee(EmployeeModel model)
        {
            Employee employeeToUpdate = mapper.Map<Employee>(model);
            employeeRepository.Update(employeeToUpdate);
        }
        public bool Delete(int id)
        {
            Employee itemToDelete = employeeRepository.GetById(id);
            return employeeRepository.Delete(itemToDelete);
        }
    }
}
