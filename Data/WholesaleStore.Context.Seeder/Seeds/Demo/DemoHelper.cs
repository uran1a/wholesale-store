using WholesaleStore.Context.Entities;

namespace WholesaleStore.Context.Seeder.Seeds.Demo;

public class DemoHelper
{
    public IEnumerable<Warehouse> GetWarehouses = new List<Warehouse>()
    {
        new Warehouse()
        {
            Location = "Воронеж, Центральный район, Московский проспект, 90/1",
            WarehouseStocks = new List<WarehouseStock>()
            {
                new WarehouseStock()
                {
                    Product = new Product()
                    {
                        Title = "Бумага А4 офисная для принтера 5 пачек (1 коробка) 2500 листов (500 листов/пачка)",
                        Description = "Бумага А4 210×297 мм офисная для принтера белая, 500 листов в пачке. Набор из 5 пачек (1 коробка). Всего 2500 листов. Предназначена для повседневной работы в офисе. Подходит для всех классов копировальных аппаратов и принтеров. Необходимая жесткость позволяет избежать заминания бумаги в принтере, а оптимальная влажность предупреждает скручивание листа. Высокий показатель непрозрачности обеспечивает хорошую читаемость текста. Экономичность позволяет копировать и печатать документы в любых необходимых объемах. Плотность: 80 г/м2",
                        Price = 2000.0,
                        Category = new Category()
                        {
                            Name = "Бумажная продукция",
                            Image = "https://img.freepik.com/free-photo/top-view-notebook-house-renovation-with-colored-pencils_23-2148815792.jpg?t=st=1716573727~exp=1716577327~hmac=3b3f23a7ec27521c016cee35facb7cdd40423eca45fe7a6e00a3488904bd4cca&w=740"
                        },
                        Images = new List<ProductImage>()
                        {
                            new ProductImage()
                            {
                                Url = "https://ir.ozone.ru/s3/multimedia-k/wc1000/6829704416.jpg",
                            },
                            new ProductImage()
                            {
                                Url = "https://ir.ozone.ru/s3/multimedia-h/wc1000/6676812881.jpg",
                            },
                            new ProductImage()
                            {
                                Url = "https://ir.ozone.ru/s3/multimedia-f/wc1000/6677656179.jpg",
                            },
                        },
                    },
                    Quentity = 10
                },

                new WarehouseStock()
                {
                    Product = new Product()
                    {
                        Title = "Ручка шариковая автоматическая Attache Comfort синяя корпус soft touch (толщина линии 0.5 мм)",
                        Description = "Ручка шариковая Attache Comfort с покрытием Soft touch. Модель с корпусом круглой формы, изготовлена из пластика синего цвета. Приятное на ощупь покрытие Soft touch не скользит и делает письмо особенно комфортным. Сменный стержень длиной 106,8 мм снабжен игольчатым наконечником и заправлен высококачественными масляными чернилами синего цвета. Диаметр пишущего узла 0,7 мм создает тонкую линию письма, равную 0,5 мм.",
                        Price = 75.0,
                        Category = new Category()
                        {
                            Name = "Письменные принадлежности",
                            Image = "https://img.freepik.com/free-photo/top-view-colorful-pencils-assortment_23-2148541499.jpg?t=st=1716573670~exp=1716577270~hmac=57789d031c57f89b861e4de2d265045e707438c572a5bd2924c751f1d399fa98&w=740"
                        },
                        Images = new List<ProductImage>()
                        {
                            new ProductImage()
                            {
                                Url = "https://media.komus.ru/medias/sys_master/root/h96/h4b/11848903032862/571480-1-800Wx800H.jpg",
                            },
                            new ProductImage()
                            {
                                Url = "https://media.komus.ru/medias/sys_master/root/h60/hc5/11848901853214/571480-3-800Wx800H.jpg",
                            },
                            new ProductImage()
                            {
                                Url = "https://media.komus.ru/medias/sys_master/root/h4e/hee/11848902246430/571480-5-800Wx800H.jpg",
                            },
                        },
                    },
                    Quentity = 20
                }

            }
        }
    };

    public IEnumerable<Category> GetCategories = new List<Category>()
    {
        new Category()
        {
            Name = "Организация и хранение",
            Image = "https://img.freepik.com/free-photo/ring-binder-used-stored-documents_23-2149512229.jpg?t=st=1716573772~exp=1716577372~hmac=0f8e8b2315a3cc0f94980fac29e64ea059f6aaad8924c133c487ac7a3c4b7201&w=740"
        }
    };
}
