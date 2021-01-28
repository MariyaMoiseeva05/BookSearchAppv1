using DAL.Entities;
using System;
using System.Linq;

namespace DAL.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BookSearchContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any())
            {
                return;
            }
            var books = new Book[]
                {
                    new Book{ Title = "Алхимик", Author = new Author { Full_name="Пауло Коэльо"}, Description = "«Алхи́мик» (порт. O Alquimista) — роман Пауло Коэльо, изданный в 1988 году и ставший мировым бестселлером. Издан более чем в 117 странах мира, переведён на 81 язык. Основной сюжет взят из европейского фольклора: по классификации фольклорных сюжетов Аарне - Томпсона - Утера — сюжет 1645 «Сокровище дома» . Типичный представитель — английская сказка «The Pedlar of Swaffham» («Сон коробейника»), а также один из эпизодов «Тысячи и одной ночи». Было выпущено более 145 тыс.книг.",
                    Publication_date = new DateTime (1988) },
                    new Book{ Title = "Книжный вор", Author = new Author { Full_name="Маркус Зусак"}, Description = "«Книжный вор» (англ. The Book Thief) — роман австралийского писателя Маркуса Зусака, написанный в 2005 году. Находился в списке «The New York Times Best Seller list» более 230 недель. Экранизирован в 2013 году режиссёром Брайаном Персивалем. В российском прокате фильм, роль Лизель в котором исполнила 13-летняя Софи Нелисс, демонстрировался под более корректным названием «Воровка книг».",
                    Publication_date = new DateTime (2005) }
                 };
            foreach (Book b in books)
            {
                context.Books.Add(b);
            }
            context.SaveChanges();

            if (context.Comments.Any())
            {
                return;
            }
            var comments = new Comment[]
                {
                     new Comment { BookID = 1, Title = "Кто слишком часто оглядывается назад, легко может споткнуться и упасть",
                     Date_of_creation = new DateTime (20/09/2020),Content = " Эмигранты. Люди покинувшие свою страну. Некоторые по доброй воле, а многие были вынуждены это сделать. Нужны ли они другой стране? Даже если ты профи в своем деле, но у тебя нет документов, ты никто. Так и жили люди на птичьих правах без Родины, без флага. Жили, не зная, что будет завтра. Жили постоянно прячась. Разве это жизнь? Сильные духом находили выход, слабые терпели, но и бойцов часто покидали силы. Книги Ремарка плотные и тяжелые. Приступая к каждому произведению, знаешь, легко не будет. Каждая страница сокращает путь к твоим эмоциям и психологически готовит место к душевному взрыву. Так же произошло и в этот раз. На протяжении всей книги было безэмоциональное восприятие. Я решила, что хоть одна книга не тянет на пятерку. Наступила развязка, которая привела меня в ступор. Я не ревела, но была на грани. На тот момент пришло осознание всего сюжета и стало стыдно за свое осуждение героев (он тряпка, она шалава). Меня переполняют эмоции, и выразить все по горячим следам тяжело. Ремарк достойный писатель!"}

                };
            foreach (Comment c in comments)
            {
                context.Comments.Add(c);
            }
            context.SaveChanges();

            if (context.Genres.Any())
            {
                return;
            }
            var genres = new Genre[]
                {
                    new Genre { NameGenre = "Менеджмент"},  new Genre { NameGenre = "О бизнесе популярно"}, new Genre { NameGenre = "Маркетинг, PR, реклама"}, new Genre { NameGenre = "Банковское дело"},new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Делопроизводство"},  new Genre { NameGenre = "Зарубежная компьютерная литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Зарубежная деловая лиетратура"},  new Genre { NameGenre = "Зарубежный юмор"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Недвижимость"},  new Genre { NameGenre = "Зарубежная старинная литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Финансы"},  new Genre { NameGenre = " Зарубежная справочная литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Малый бизнес"},  new Genre { NameGenre = "Зарубежная эзотерическая литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Отраслевые издания"},  new Genre { NameGenre = " Зарубежная религиозная литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Государственное  и муниципальное управление"}, new Genre { NameGenre = "Зарубежные боевики"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Тайм-менеджмент"}, new Genre { NameGenre = "Зарубежная психология"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Менеджмент и кадры"}, new Genre { NameGenre = "Зарубежные приключения"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Работа с клиентами"}, new Genre { NameGenre = "Зарубежная религиозная и эзотерическая литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Политическое управление"}, new Genre { NameGenre = "Зарубежная публицистика"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Стартапы и создание бизнеса"}, new Genre { NameGenre = "Зарубежная прикладная литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Корпоративная культура"}, new Genre { NameGenre = "Зарубежная драматургия"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Переговоры"}, new Genre { NameGenre = "Зарубежная литература о культуре и искусстве"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Личная эффективность"}, new Genre { NameGenre = "Зарубежная фантастика"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Личные финансы"}, new Genre { NameGenre = "Зарубежные детские книги"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Ораторское искусство, риторика"}, new Genre { NameGenre = "Современная зарубежная литература"}, new Genre { NameGenre = ""}, new Genre { NameGenre = ""},  new Genre { NameGenre = ""},
                    new Genre { NameGenre = "Риторика"},
                    new Genre { NameGenre = "Продажи"},
                    new Genre { NameGenre = "Интернет-бизнес"},
                    new Genre { NameGenre = "Ценные бумаги, инвестиции"},
                    new Genre { NameGenre = "Бухучет, налогообложение, аудит"},
                    new Genre { NameGenre = "Поиск работы, карьера"},
                    new Genre { NameGenre = "Кадровый менеджмент"},
                    new Genre { NameGenre = "Экономика"},
                    new Genre { NameGenre = "Зарубежная классика"},
                    new Genre { NameGenre = "Русская классика"},
                    new Genre { NameGenre = "Литература XX века"},
                    new Genre { NameGenre = "Фольклор"},
                    new Genre { NameGenre = "Литература XIX века"},
                    new Genre { NameGenre = "Европейская старинная литература"},
                    new Genre { NameGenre = "Зарубежная старинная литература"},
                    new Genre { NameGenre = "Древнерусская литература"},
                    new Genre { NameGenre = "Классическая проза"},
                    new Genre { NameGenre = "Старинная литература"},
                    new Genre { NameGenre = "Мифы, легенды, эпос"},
                    new Genre { NameGenre = "Советская литература"},
                    new Genre { NameGenre = "Античная литература"},
                    new Genre { NameGenre = "Литература XVIII века"},
                    new Genre { NameGenre = "Древневосточная литература"},
                    new Genre { NameGenre = "Зарубежная классика "},
                    new Genre { NameGenre = "Зарубежные любовные романы"},
                    new Genre { NameGenre = "Зарубежные детективы"},
                    new Genre { NameGenre = "Зарубежное фэнтези"},
                    new Genre { NameGenre = "Зарубежная деловая литература"},
                    new Genre { NameGenre = "Зарубежная поэзия"},
                    new Genre { NameGenre = "Зарубежная образовательная литература"},
                };

            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();

            if (context.Type_Of_Literatures.Any())
            {
                return;
            }
            var types = new Type_of_literature[]
                {
                    new Type_of_literature{ Name_Type = "Бизнес-книги" },
                    new Type_of_literature{ Name_Type = "Классическая литература" },
                    new Type_of_literature{ Name_Type = "Зарубежная литература" },
                    new Type_of_literature{ Name_Type = "Русская литература" },
                    new Type_of_literature{ Name_Type = "Детские книги" },
                    new Type_of_literature{ Name_Type = "Детективы" },
                    new Type_of_literature{ Name_Type = "Фэнтези" },
                    new Type_of_literature{ Name_Type = "Фантастика" },
                    new Type_of_literature{ Name_Type = "Современная проза" },
                    new Type_of_literature{ Name_Type = "Приключения" },
                    new Type_of_literature{ Name_Type = "Ужасы, мистика" },
                    new Type_of_literature{ Name_Type = "Публицистическая литература" },
                    new Type_of_literature{ Name_Type = "Книги для подростков" },
                    new Type_of_literature{ Name_Type = "Любовные романы" },
                    new Type_of_literature{ Name_Type = "Боевики, остросюжетная литература" },
                    new Type_of_literature{ Name_Type = "Книги по психологии" },
                    new Type_of_literature{ Name_Type = "Повести, рассказы" },
                    new Type_of_literature{ Name_Type = "Поэзия, драматургия" },
                    new Type_of_literature{ Name_Type = "Наука и образование" },
                    new Type_of_literature{ Name_Type = "Дом, семья, хобби и досуг" },
                    new Type_of_literature{ Name_Type = "Комиксы, манга" },
                    new Type_of_literature{ Name_Type = "Эзотерика" },
                    new Type_of_literature{ Name_Type = "Культура и искусство" },
                    new Type_of_literature{ Name_Type = "Юмористическая литература" },
                    new Type_of_literature{ Name_Type = "Религия" },
                    new Type_of_literature{ Name_Type = "Словари" },
                    new Type_of_literature{ Name_Type = "Справочники" },
                    new Type_of_literature{ Name_Type = "Красота и здоровье" },
                    new Type_of_literature{ Name_Type = "Книги на иностранных языках" },
                    new Type_of_literature{ Name_Type = "Компьютерная литература" },
                    new Type_of_literature{ Name_Type = "Эротика и секс" },
                    new Type_of_literature{ Name_Type = "Периодические издания" },
                    new Type_of_literature{ Name_Type = "Учебная литература" },
                    new Type_of_literature{ Name_Type = "Исторический роман" },
                    new Type_of_literature{ Name_Type = "Магический реализм" },
                    new Type_of_literature{ Name_Type = "ЛГБТ" },
                    new Type_of_literature{ Name_Type = "Реализм" }
                 };
            foreach (Type_of_literature t in types)
            {
                context.Type_Of_Literatures.Add(t);
            }
            context.SaveChanges();

        }
    }
}
