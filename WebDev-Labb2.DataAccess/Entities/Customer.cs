﻿namespace WebDev_Labb2.DataAccess.Entities;

public class Customer
{
    public int CustomerID { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<Order> Orders { get; set; } = new();
}