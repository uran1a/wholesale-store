using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Seeder.Seeds.Demo;

public class DemoHelper
{
    public IEnumerable<Warehouse> GetWarehouses = new List<Warehouse>
    { 
        new Warehouse()
        {
            Address = "г. Воронеж, Шишкова 101а",
            Racks = new List<Rack>()
            {
                new Rack()
                {
                    Length = 1.5,
                    Width = 0.2,
                    Height = 0.75,
                    PositionX = 0,
                    PositionY = 0,  
                    Shelves = new List<Shelf>()
                    {
                        new Shelf()
                        {
                            Level = 1,
                            Height = 0.25,
                            LoadCapacity = 30,
                        }
                    }
                }
            }
        }
    };
    public IEnumerable<Product> GetProducts = new List<Product>()
    {
        new Product()
        {
            Title = "Бумага А4 офисная для принтера 5 пачек (1 коробка) 2500 листов (500 листов/пачка)",
            Description = "Бумага А4 210×297 мм офисная для принтера белая, 500 листов в пачке. Набор из 5 пачек (1 коробка). Всего 2500 листов. Предназначена для повседневной работы в офисе. Подходит для всех классов копировальных аппаратов и принтеров. Необходимая жесткость позволяет избежать заминания бумаги в принтере, а оптимальная влажность предупреждает скручивание листа. Высокий показатель непрозрачности обеспечивает хорошую читаемость текста. Экономичность позволяет копировать и печатать документы в любых необходимых объемах. Плотность: 80 г/м2",
            Weight = 12.5,
            Price = 2000.0,
            Box = new Box()
            {
                Length = 0.30,
                Width = 0.27,
                Height = 0.21
            },
            Categories = new List<Category>()
            {
                new Category()
                {
                    Title = "Ручки и карандаши",
                },
                new Category()
                {
                    Title = "Бумажная продукция",
                },
                new Category()
                {
                    Title = "Офисные принадлежности",
                }
            },
            WarehouseProducts = new List<WarehouseProduct>()
            {
                new WarehouseProduct()
                {
                    PositionX = 0,
                    PositionY = 0,
                    ShelfId = 1
                }
            }
        }
    };
}
