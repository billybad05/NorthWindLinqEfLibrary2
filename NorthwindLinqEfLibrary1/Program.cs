using NorthWIndLinqEfLibrary2.Models;
using NorthWIndLinqEfLibrary2.Controllers;

Console.WriteLine("Northwind Linq EF Library");

AppDbContext _context = new();

EmployeesController emplCtrl = new(_context);
CustomersController custCtrl = new(_context);

var customer = await custCtrl.GetByPK("ALFKX");

    Print(customer?.ToString() ?? "Customer not found!");


//Customer cust = new() { CustomerId = "XXXXX", CompanyName = "X=Star" };

//Customer? x5 = custCtrl.GetByPK("XXXXX");

//x5.ContactName = "Noah Phence";

//custCtrl.Update(x5.CustomerId, x5);
//custCtrl.Insert(cust);
//custCtrl.Delete("XXXXX")
//Customer cust = custCtrl.GetByPK("ABCDE");

//Print(cust);
/*
var custs = custCtrl.Contains("C"); 

foreach(Customer cus in custs) {
    Print(cus);
}
*/
/*
var empls = emplCtrl.Contains("ll");

foreach(Employee emp in empls) {
    Print(emp);
}
*/
//emplCtrl.Delete(10);
/*
//Employee? empl1 = emplCtrl.GetByPK(1);
Employee? newEmpl = new() {
    EmployeeId = 0, LastName = "Phence", FirstName = "Noah",
    Title = "Joker", TitleOfCourtesy = "Mr.", BirthDate = new DateTime(2022, 9, 12),
};
*/
//emplCtrl.Insert(newEmpl);

//Print(newEmpl);

//empl1.TitleOfCourtesy = "Ms.";

//emplCtrl.Update(1, empl1);

//Print(empl1);

void Print (object obj)
{
    if (obj is null)
        obj = "(NULL)";
    Console.WriteLine(obj);
    System.Diagnostics.Debug.WriteLine(obj.ToString());
}
