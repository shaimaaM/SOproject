using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOproject.Models
{
    public class SlaesOrderHeaderAndLines
    {
    

public class Rootobject
{
    public string odatacontext { get; set; }
    public Value[] value { get; set; }
}

public class Value
{
    public string odataetag { get; set; }
    public string No { get; set; }
    public string Sell_to_Customer_No { get; set; }
    public string Sell_to_Customer_Name { get; set; }
    public string Order_Date { get; set; }
    public string Shipment_Date { get; set; }
    public string Phone_No { get; set; }
    public string Receiver_E_Mail { get; set; }
    public string Posting_Description { get; set; }
    public string CRM_Cost_Amount { get; set; }
    public bool COD { get; set; }
 
    public string SalesOrderSalesLinesodatacontext { get; set; }
    public Salesordersalesline[] SalesOrderSalesLines { get; set; }
}

public class Salesordersalesline
{
    public string odataetag { get; set; }
    public string No { get; set; }

    public string Description { get; set; }
   
    public int Quantity { get; set; }
  
    public int Unit_Price { get; set; }
    public bool Tax_Liable { get; set; }
 
    public int Line_Amount { get; set; }
    public int Amount_Including_VAT { get; set; }

    public int Quantity_Shipped { get; set; }
    public int Qty_to_Invoice { get; set; }
    public int Quantity_Invoiced { get; set; }
   
    public string Shipment_Date { get; set; }
  
  
   
    public int Quantity_Base { get; set; }
 
    public string Tracking_No { get; set; }
    public string Tracking_URL { get; set; }
    public string Status { get; set; }
 
    public string Job_No { get; set; }

  
}
    }
}
