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
    public IEnumerable<Category> GetCategories = new List<Category>()
    {
        new Category()
        {
            Name = "Ручки и простые карандаши",
        },
        new Category()
        {
            Name = "Тетради и блокноты",
        },
        new Category()
        {
            Name = "Папки разных видов и файлы",
        },
    };

    public IEnumerable<Product> GetProducts = new List<Product>()
    {
        new Product()
        {
            Title = "Бумага А4 офисная для принтера 5 пачек (1 коробка) 2500 листов (500 листов/пачка)",
            Description = "Бумага А4 210×297 мм офисная для принтера белая, 500 листов в пачке. Набор из 5 пачек (1 коробка). Всего 2500 листов. Предназначена для повседневной работы в офисе. Подходит для всех классов копировальных аппаратов и принтеров. Необходимая жесткость позволяет избежать заминания бумаги в принтере, а оптимальная влажность предупреждает скручивание листа. Высокий показатель непрозрачности обеспечивает хорошую читаемость текста. Экономичность позволяет копировать и печатать документы в любых необходимых объемах. Плотность: 80 г/м2",
            Price = 2000.0,
            Quantity = 10,
            Category = new Category()
            {
                Name = "Бумага для принтера",
            },
            Images = new List<Image>()
            {
                new Image()
                {
                    Url = "https://ir.ozone.ru/s3/multimedia-k/wc1000/6829704416.jpg",
                },
                new Image()
                {
                    Url = "https://ir.ozone.ru/s3/multimedia-h/wc1000/6676812881.jpg",
                },
                new Image()
                {
                    Url = "https://ir.ozone.ru/s3/multimedia-f/wc1000/6677656179.jpg",
                },
            },
        }
    };
}
