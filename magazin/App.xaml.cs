using InventoryOfEquipment.Lib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace magazin
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DB db = new DB("194.169.163.29", "pfv", "ohjat", "ohjat123");
    }
}
