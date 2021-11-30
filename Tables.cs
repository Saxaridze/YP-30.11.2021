using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Подай_на_16
{
    [Table (Name = "Gender")]
    public class Gender
    {
        [Column (IsDbGenerated =false, IsPrimaryKey =true)]
        public string Code { get; set; }
        [Column]
        public string Name { get; set; }
    }
    [Table(Name = "Client")]
    public class Client
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string FirstName { get; set; }
        [Column]
        public string LastName { get; set; }
        [Column]
        public string Patronymic { get; set; }
        [Column]
        public DateTime Birthday { get; set; }
        [Column]
        public DateTime RegistrationDate { get; set; }
        [Column]
        public string Email { get; set; }
        [Column]
        public string Phone { get; set; }
        [Column]
        public string GenderCode { get; set; }
        [Column]
        public string PhotoPath { get; set; }
    }
    [Table(Name = "Service")]
    public class Service
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public decimal Cost { get; set; }
        [Column]
        public int DurationInSeconds { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public decimal Discount { get; set; }
        [Column]
        public string MainImagePath { get; set; }
    }
    [Table(Name = "ClientService")]
    public class ClientService
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public int ClientID { get; set; }
        [Column]
        public int ServiceID { get; set; }
        [Column]
        public DateTime StartTime { get; set; }
        [Column]
        public string Comment { get; set; }
    }
}
