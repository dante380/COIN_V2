using CakeShop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Persistence
{
    public static class DbInitializer
    {
        public static async Task SeedDatabaseAsync(
            CakeShopDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            System.Console.WriteLine("Seeding... - Start");

            var categories = new List<Category>
            {
                new Category { Name = "Phones"},
                new Category { Name = "Internet"},
                new Category { Name = "Taxes"},
                new Category { Name = "Games"}
            };

            var cakes = new List<Cake>
            {
                new Cake
                {
                    Name ="Kievstar",
                    Price = 1.00M,
                    ShortDescription ="пополнить мобильный номер",
                    LongDescription ="Київстар - одним з найбільш відомих і популярних операторів мобільного зв'язку, який надає різні пакети, тарифи і послуги абонентам мобільного зв'язку. Покриття у цього оператора мобільного зв'язку охоплює всю територію України, а послуги роумінга доступні по всьому світу. Сплатити за послуги мобільного зв'язку за номером телефону можна як на території України, так і за кордоном за допомогою нашого сайту в інтернеті і банківської картки (можливо навіть без її наявності за умови, що Вам відомі її реквізити). Незалежно від країни з якої здійснюється доступ в інтернет оплата на нашому сайті здійснюється швидко і безпечно, а зарахування коштів на Ваш рахунок майже моментально.",
                    Category = categories[0],
                    ImageUrl ="/img/kievstar.jpg",
                    IsCakeOfTheWeek = true,
                },
                new Cake
                {
                    Name ="Vodafone",
                    Price = 1.00M,
                    ShortDescription ="пополнить мобильный номер",
                    LongDescription ="Поповнити рахунок Vodafone, а також сплатити інші послуги, що надаються цим оператором мобільного зв'язку на нашому сайті. Для цього необхідно мати в наявності (або просто знати дані) платіжної картки Visa или MasterCard і правильно заповнити необхідні поля на сайті. Ми прагнемо зробити послугу оплати доступною, якісною і передбачити всі можливі опції для кожного випадку і кожного клієнта.",
                    Category = categories[0],
                    ImageUrl ="/img/vodafone.jpg",
                    IsCakeOfTheWeek = true,
                },
                new Cake
                {
                    Name ="triolan",
                    Price =150.00M,
                    ShortDescription ="оплатить интернет",
                    LongDescription ="Тріолан - одна з найбільших телекомунікаційних мереж, яка надає свої послуги в таких містах України як Київ, Харків, Дніпро, Одеса, Суми, Полтава, Запоріжжя, Рівне і заявляє про те, що це не є межею. Тріолан надає такі послуги: інтернет, телебачення, ІР-телефонія, домофони, відеонагляд. Всі послуги компанії доступні всім категоріям абонентів. Для зручності користувачів служба підтримки працює цілодобово.",
                    Category = categories[1],
                    ImageUrl ="/img/triolan.jpg",
                    IsCakeOfTheWeek = true,
                },
                new Cake
                {
                    Name ="lanet",
                    Price = 149.95M,
                    ShortDescription ="оплатить интернет",
                    LongDescription ="Ланет є одним з найбільш поширених інтернет провайдерів м.Києва. Також компанія надає свої послуги в Володимир-Волинському, Дрогобичі, Івано-Франківську, калуші, Кам'янець-Подільскому і постійно розширює своє покриття. Підключення до інтернету від Ланет є безкоштовним, а тарифи досить гнучкими. Також надається пакетне обслуговування щодо інтернету і телебачення. Серед інших послуг компанії можна виділити надання ІР-адрес, смс-інформ, антивірусний захист, подарункові сертифікати та інші. За всі послуги Ланет можна сплатити на нашому сайті з будь-якої точки світу, просто і швидко за допомогою банківської платіжної картки Visa або MasterCard.",
                    Category = categories[1],
                    ImageUrl ="/img/lanet.jpg",
                    IsCakeOfTheWeek = true,
                },
                new Cake
                {
                    Name ="Kievvodokanal",
                    Price= 100.00M,
                    ShortDescription ="оплата комуналбных платежей",
                    LongDescription ="Київводоканал – найстаріше і найпотужніше водопостачальне підприємство України та одне з найбільших у Європі Наша історія тісно пов'язана з історією міста Києва. Протягом півтори тисячі років свого існування Київ, одне з найбільших міст Європи, не міг обійтися без систем водопостачання і каналізації, у процесі розвитку яких завжди знаходили застосування найцікавіші технологічні новинки кожної епохи.",
                    Category = categories[2],
                    ImageUrl ="/img/kievvodokanal.jpg",
                    IsCakeOfTheWeek = true,
                },
                new Cake
                {
                    Name ="Steam",
                    Price = 10.00M,
                    ShortDescription ="пополнить Steam",
                    LongDescription ="Steam — сервіс компанії Valve, відомого розробника відеоігор, який надає послуги цифрової дистрибуції, багатокористувацьких ігор і спілкування гравців.",
                    Category = categories[3],
                    ImageUrl ="/img/steam.jpg",
                    IsCakeOfTheWeek = true,
                }

            };

            if (!context.Categories.Any() && !context.Cakes.Any())
            {
                context.Categories.AddRange(categories);
                context.Cakes.AddRange(cakes);
                context.SaveChanges();
            }


            IdentityUser usr = null;
            string userEmail = configuration["Admin:Email"] ?? "admin@admin.com";
            string userName = configuration["Admin:Username"] ?? "admin";
            string password = configuration["Admin:Password"] ?? "Passw@rd!123";

            if (!context.Users.Any())
            {
                usr = new IdentityUser
                {
                    Email = userEmail,
                    UserName = userName
                };
                await userManager.CreateAsync(usr, password);
            }

            if (!context.UserRoles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            }
            if (usr == null)
            {
                usr = await userManager.FindByEmailAsync(userEmail);
            }
            if (!(await userManager.IsInRoleAsync(usr, "Admin")))
            {
                await userManager.AddToRoleAsync(usr, "Admin");
            }

            context.SaveChanges();

            System.Console.WriteLine("Seeding... - End");
        }

    }
}