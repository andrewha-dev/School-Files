using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Schema;

namespace aha_C50_A03.Models
{
    //Enums
    public enum productCategory
    {
        Other,
        Art,
        Beverages,
        Electronics,
        Home,
        Music,
        Sporting,
        Toys,
    }
    public class ShoppingEntry
    {
        public int id { get; set; }
        [DisplayName("Category:")]
        public productCategory category { get; set; }
        [DisplayName("Product Name:")]
        public string productName { get; set; }
        [DisplayName("Price:")]
        public string price { get; set; }
        [DisplayName("Quantity:")]
        public int quantity { get; set; }
        
    }

    public class ShoppingList
    {
        List<ShoppingEntry> myShoppingList;
        private static ShoppingList instance = null;

        private ShoppingList()
        {
            myShoppingList = null;
        }

        public List<ShoppingEntry> GetList()
        {
            return myShoppingList;
        }

        public static ShoppingList Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingList();
                    instance.myShoppingList = new List<ShoppingEntry>();
                    if (!ValidateXML())
                    {
                        //Loading the shopping list from the XML file
                        XElement xelement = XElement.Load(HostingEnvironment.MapPath("~/App_Data/shoppingList.xml"));
                        int id = 1;
                        foreach (XElement xEle in xelement.Descendants("ShoppingEntry"))
                        {
                            ShoppingEntry entry = new ShoppingEntry();
                            entry.id = id++;
                            productCategory cat;
                            Enum.TryParse((string)xEle.Element("Product").Attribute("Category").Value, out cat);
                            entry.category = cat;
                            entry.productName = xEle.Element("Product").Element("Name").Value;
                            entry.price = xEle.Element("Product").Element("Price").Value;
                            entry.quantity = Convert.ToInt16(xEle.Element("Quantity").Value);

                            instance.myShoppingList.Add(entry);
                        }
                    }
                    else
                    {
                        instance.myShoppingList.Add(new ShoppingEntry()
                        {
                            id = 1,
                            category = productCategory.Other,
                            productName = "Error Loading XML file - Did not Validate against schema",
                            price = "$0.00",
                            quantity = -999
                        });
                    }
                    

                }
                return instance;
            }
        }

        public ShoppingEntry getEntry(int id)
        {
            ShoppingEntry curr = instance.GetList().Find(b => b.id == id);
            return curr;
        }

        public void updateList(int id, ShoppingEntry entry)
        {
            if (!CheckForDuplicateEdit(id, entry.productName))
            {
            ShoppingEntry curr = instance.GetList().Find(b => b.id == id);
            var index = instance.GetList().IndexOf(curr);
            curr.id = id;
            instance.GetList()[index] = entry;
            UpdateXML();
            }
            
        }

        public void Create(ShoppingEntry entry)
        {
            entry.id = instance.GetList().Max(b => b.id) + 1;
            //Need to run check if there are duplicate productNames
            if (!CheckForDuplicate(entry.productName))
            {
            instance.GetList().Add(entry);
            UpdateXML();
            }
            
        }

        public void Delete(int id)
        {
            instance.GetList().Remove(instance.GetList().Find(b => b.id == id));
            UpdateXML();
        }

        public double CalculatePrice()
        {
            double price = 0.0;
            foreach (ShoppingEntry entry in instance.GetList())
            {
                string removedDollarSign = entry.price.Replace("$", "");
                double productPrice = Convert.ToDouble(removedDollarSign);
                price += productPrice * entry.quantity;
            }
            return price;
        }

        public void UpdateXML()
        {
            XDocument doc = new XDocument(new XElement("ShoppingList"
                    //new XAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    //new XAttribute("xsi:noNamespaceSchemaLocation", "shoppingList.xsd")
                ));

            doc.Add(new XComment("Andrew Ha - 420-C50 - A03"));

            foreach (ShoppingEntry entry in myShoppingList)
            {
                doc.Root.Add(new XElement("ShoppingEntry",
                    new XElement("Product",
                    new XAttribute("Category", entry.category),
                    new XElement("Name", entry.productName),
                    new XElement("Price", entry.price)),
                    new XElement("Quantity", entry.quantity)             


                    ));
            }
            doc.Save(HostingEnvironment.MapPath("~/App_Data/shoppingList.xml"));
        }

        public bool CheckForDuplicate(string name)
        {
            bool duplicate = instance.GetList().Any(entry => entry.productName.ToLower().Equals(name.ToLower()));
            return duplicate;
        }

        public bool CheckForDuplicateEdit(int id, string name)
        {
            bool duplicate = instance.GetList().Where(e=> e.id != id).Any(entry => entry.productName.ToLower().Equals(name.ToLower()));
            return duplicate;
        }

        public static bool ValidateXML()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", HostingEnvironment.MapPath("~/App_Data/shoppingList.xsd"));

            XDocument shoppingList = XDocument.Load(HostingEnvironment.MapPath("~/App_Data/shoppingList.xml"));
            bool errors = false;
            shoppingList.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            
            return errors;
        }
    }


}