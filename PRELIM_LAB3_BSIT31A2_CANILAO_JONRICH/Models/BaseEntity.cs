using System;

namespace PRELIM_LAB3_BSIT31A2_CANILAO_JONRICH.Models
{
    interface IDescription
    {
        string Describe();
    }

    public class BaseEntity : IDescription
    {
        // Properties
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public DateTime birthday { get; set; }

        // Get full name
        public string FullName()
        {
            return $"{firstname} {middlename} {lastname}".Trim();
        }

        // Calculate age
        public int GetAge()
        {
            var today = DateTime.Today;
            int age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age;
        }

        // Implement Describe for base entity (can be abstract, but let's keep a default)
        public virtual string Describe()
        {
            return $"Customer: {FullName()}, Age: {GetAge()}";
        }
    }

    public class Customer : BaseEntity
    {
        public string CustomerID { get; set; }

        // Override Describe to include CustomerID
        public override string Describe()
        {
            return $"{base.Describe()}, Customer ID: {CustomerID}";
        }
    }

    public class VipCustomers : Customer
    {
        // Override Describe to indicate VIP customer
        public override string Describe()
        {
            return $"VIP Customer: {FullName()}, Age: {GetAge()}, Customer ID: {CustomerID}";
        }
    }
}