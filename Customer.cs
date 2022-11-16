using System;

namespace Activity_1
{
    public class Customer
    {
        private int id;
        private string name;
        private int age;
        private string email;
        private long phone;
        private char grade;

        public static int num = 000;
        public int Customer_id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public Customer()
        {
            num++;
            this.Customer_id = num;
        }
        public string customer_name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int customer_age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string customer_mail
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public long customer_mobile
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public char customer_grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }
    }
}
