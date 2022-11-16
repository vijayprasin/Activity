using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Activity_1
{

    /*compareId,comparegrade,compareAge classes are helps in custom sorting the list 
    according to  User requirement*/
    public class compareId : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            return x.Customer_id.CompareTo(y.Customer_id);
        }
    }
    public class comparegrade : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            if (x.customer_grade == y.customer_grade)
            {
                return x.customer_age.CompareTo(y.customer_age);
            }
            return x.customer_grade.CompareTo(y.customer_grade);
        }
    }
    public class compareAge : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            if (x.customer_grade == y.customer_grade)
            {
                return x.customer_grade.CompareTo(y.customer_grade);
            }
            return x.customer_age.CompareTo(y.customer_age);
        }
    }
    public class Program
    {
        public static void Animation(string name)
        {

            for (int i = 0; i < name.Length; i++)
            {
                Console.Write(name[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
        public static int returnAge()
        {
            Console.Write("Enter your age: ");
            int num;
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out num))
                {
                    Console.WriteLine("Enter Valid age");
                    continue;
                }
                else
                {
                    num = int.Parse(input);
                    if (num <= 0)
                    {
                        Console.WriteLine("Enter Valid age, Age must be greater than 0");
                        continue;
                    }
                    break;
                }
            }
            return num;
        }
        public static string returnEmail()
        {
            Console.Write("Enter your email address: ");
            string mail = string.Empty;
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Contains("@") && input.Contains(".com"))
                {
                    mail = input;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter valid email Address");
                    Console.ResetColor();
                    continue;
                }
            }
            return mail;
        }
        public static long returnMobile()
        {
            Console.Write("Enter Your Mobile Number: ");
            long num;
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Length != 10)
                {
                    Console.WriteLine("Mobile Number must consist of 10 digits");
                    continue;
                }
                else
                {
                    if (!long.TryParse(input, out num))
                    {
                        Console.WriteLine("Enter Valid Number");
                        continue;
                    }
                    else
                    {
                        num = long.Parse(input);
                        if (num <= 0)
                        {
                            Console.WriteLine("Enter Valid Number");
                            continue;
                        }
                        break;
                    }
                }

            }
            return num;
        }
        public static char returnGrade()
        {
            Console.WriteLine("Enter Grade: A or B or C");
            char grade;
            while (true)
            {
                string input = Console.ReadLine().ToUpper().Trim();
                if (input.Length != 1)
                {
                    Console.WriteLine("Please choose proper grade");
                    continue;
                }
                else
                {
                    if (input.Equals("A") || input.Equals("B") || input.Equals("C"))
                    {
                        grade = char.Parse(input);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please choose proper grade");
                        continue;
                    }
                }

            }
            return grade;
        }
        public static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("---------------- CUSTOMER DETAILS FILLING AREA -----------------");
            Console.WriteLine("Please enter the Command as per Action\n");

            Console.WriteLine("Create(Customer registation)             ----> C");
            Console.WriteLine("Update(Customer can update detials)      ----> U");
            Console.WriteLine("Search(Search by customer Id             ----> S");
            Console.WriteLine("Read(List of customers)                  ----> R");
            Console.WriteLine("Delete(Delete Registation)               ----> D");
            Console.WriteLine("Custom List(List as per sorting)         ----> CL");
            Console.WriteLine("Exit(Out of the application)             ----> E");
            Console.WriteLine();
            Console.Write("Enter Command:");
            string performance = string.Empty;
            while (true)
            {
                string input = Console.ReadLine().ToUpper().Trim();
                if (input.Equals("C") || input.Equals("U") || input.Equals("S") || input.Equals("R") || input.Equals("D") || input.Equals("CL") || input.Equals("E"))
                {
                    performance = input;
                    break;
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please choose According to Menu");
                    //Console.ResetColor();
                    Console.Write("Enter Command:");
                    continue;
                }
            }
            return performance;
        }
        static void Main(string[] args)
        {
            List<Customer> customerList = new List<Customer>();
            
            while (true)
            {
                string action = menu();
                Console.WriteLine("-----------------------------------");
                switch (action)
                {
                    case "C":
                        string heading = "Registration Form";
                        Console.SetCursorPosition((Console.WindowWidth - heading.Length) / 2, Console.CursorTop);
                        
                        Console.WriteLine(heading);
                       

                        Console.WriteLine("Enter your name");
                        string name = Console.ReadLine();
                        int age = returnAge();
                        string mail = returnEmail();
                        long mobile = returnMobile();
                        char grade = returnGrade();
                        if (customerList.Any(x => x.customer_mail == mail))
                        {
                            
                            Console.WriteLine("Sorry! Email already in use Please Try another Email");
                            
                            break;
                        }
                        customerList.Add(new Customer() { customer_name = name, customer_age = age, customer_mail = mail, customer_mobile = mobile, customer_grade = grade });
                        Console.WriteLine();
                        
                        Console.WriteLine("Thank You!");
                        Console.WriteLine("Your Account has been created Successfully");
                        
                        Console.WriteLine("Hello {0}", name);
                        Console.WriteLine("Your customer Id is {0}", Customer.num);
                        
                        break;
                    case "U":
                        Console.WriteLine("Update Your Details");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Enter customer Id");
                        int updateid = Convert.ToInt32(Console.ReadLine());
                        var obj1 = customerList.FirstOrDefault(x => x.Customer_id == updateid);
                        obj1.customer_mobile = returnMobile();
                        obj1.customer_grade = returnGrade();
                        
                        Console.WriteLine("Your details updated successfully");
                        
                        Console.WriteLine();
                        break;
                    case "S":
                        Console.WriteLine("Search customer details");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine();
                        Console.WriteLine("Enter customer id");
                        int searchid = Convert.ToInt32(Console.ReadLine());
                        var obj = customerList.FirstOrDefault(x => x.Customer_id == searchid);
                        Console.WriteLine("Name      : {0}", obj.customer_name);
                        Console.WriteLine("Age       : {0}", obj.customer_age);
                        Console.WriteLine("Email     : {0}", obj.customer_mail);
                        Console.WriteLine("Mobile    : {0}", obj.customer_mobile);
                        Console.WriteLine("Grade     : {0}", obj.customer_grade);
                        Console.WriteLine();
                        break;
                    case "R":
                        if (customerList.Count == 0)
                        {
                            
                            Console.WriteLine("Still no one yet registered in ABC company");
                            
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("All the customer details");
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                            Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-30} {4,-18} {5,-15}", "Customer Id", "Name", "Age", "Email", "Mobile", "Grade");
                            Console.WriteLine();
                            foreach (var ob in customerList)
                            {
                                Console.WriteLine("{0,-15} {1,-15} {2,-15} {3,-30} {4,-18} {5,-15}", ob.Customer_id, ob.customer_name, ob.customer_age, ob.customer_mail, ob.customer_mobile, ob.customer_grade);
                            }
                            Console.WriteLine("-------------------------------------------------------------------------------------");
                        }
                        compareId objid = new compareId();
                        customerList.Sort(objid);
                        Console.WriteLine();
                        break;
                    case "D":
                        Console.WriteLine("Delete Customer Details");
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Enter customer Id");
                        int delId = Convert.ToInt32(Console.ReadLine());
                        var delObj = customerList.FirstOrDefault(x => x.Customer_id == delId);
                        if (delObj != null)
                        {
                            customerList.Remove(delObj);
                            
                            Console.WriteLine("Customer registation has been Deleted");
                            
                        }
                        else
                        {
                       
                            Console.WriteLine("There are no customer details available on this id");
                            
                        }
                        Console.WriteLine();
                        break;
                    case "CL":
                        Console.WriteLine("Do you want to sort the List as below");
                        Console.WriteLine("Sort by Age ascending order ===> SBA");
                        Console.WriteLine("Sort by Grade               ===> SBG");
                        string input = Console.ReadLine().ToUpper();
                        if (input.Equals("SBA"))
                        {
                            compareAge objAge = new compareAge();
                            customerList.Sort(objAge);
                            Console.WriteLine("According to their Age");
                            goto case "R";
                        }
                        else if (input.Equals("SBG"))
                        {
                            comparegrade objGrade = new comparegrade();
                            customerList.Sort(objGrade);
                            Console.WriteLine("According to their Grade");
                            goto case "R";
                        }
                        break;
                    default:
                        break;
                }

                if (action.Equals("E"))
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

