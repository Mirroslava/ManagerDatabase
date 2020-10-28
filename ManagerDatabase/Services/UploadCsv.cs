using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using ManagerDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagerDatabase.Services
{
    public class UploadCsv
    {
       

        public UploadCsv()
        {
            
        }

        public List<Manager> GetAll()
        {
            //IEnumerable<Manager> records;
            //using (var reader = new StreamReader("/Users/barabasmiroslava/Documents/ManagerCsv.csv"))
            //using (var csvReader = new CsvReader((IParser)reader))
            //{
            //     records = csvReader.GetRecords<Manager>();
            //}
            var employees = new List<Manager>();
            using (var sreader = new StreamReader("/Users/barabasmiroslava/Documents/ManagerCsv.csv"))
            {
                //First line is header. If header is not passed in csv then we can neglect the below line.
                string[] headers = sreader.ReadLine().Split(',');
                //Loop through the records
                while (!sreader.EndOfStream)
                {
                    string[] rows = sreader.ReadLine().Split(',');

                    employees.Add(new Manager
                    {
                        Id = int.Parse(rows[0].ToString()),
                        Name = rows[1].ToString(),
                       
                        Salary = int.Parse(rows[3].ToString())
                    });
                }
            }


            return employees;
        }

        
    }
}
