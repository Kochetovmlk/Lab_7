using Lab_07.comment;

namespace Lab_07.myclass
{
    [Comment("Class for Cow")]  // Атрибут CommentAttribute для указания комментария к классу.
    public class Cow : Animal  // Объявление класса Cow, который наследует от абстрактного класса Animal.
    {
        // Конструктор класса Cow.
        public Cow(string Country, string HideFromOtherAnimal, string Name, string WhatAnimal) : base(Country, HideFromOtherAnimal, Name, WhatAnimal)
        {
            // Вызов конструктора базового класса Animal для инициализации свойств.
        }

        // Переопределенный метод SayHello.
        public override void SayHello()
        {
            base.SayHello();  // Вызов метода базового класса.
            Console.WriteLine(", i'm a Cow.");  // Вывод строки в консоль.
        }

        // Переопределенный метод GetFavoriteFood.
        public override eFavoriteFood GetFavoriteFood()
        {
            return base.GetFavoriteFood();  // Вызов метода базового класса и возвращение его значения.
        }
    }

    [Comment("Class for Lion")]  // Атрибут CommentAttribute для указания комментария к классу.
    public class Lion : Animal  // Объявление класса Lion, который наследует от абстрактного класса Animal.
    {
        // Конструктор класса Lion.
        public Lion(string Country, string HideFromOtherAnimal, string Name, string WhatAnimal) : base(Country, HideFromOtherAnimal, Name, WhatAnimal)
        {
            // Вызов конструктора базового класса Animal для инициализации свойств.
        }

        // Переопределенный метод SayHello.
        public override void SayHello()
        {
            base.SayHello();  // Вызов метода базового класса.
            Console.WriteLine(", i'm a Lion.");  // Вывод строки в консоль.
        }

        // Переопределенный метод GetFavoriteFood.
        public override eFavoriteFood GetFavoriteFood()
        {
            return base.GetFavoriteFood();  // Вызов метода базового класса и возвращение его значения.
        }
    }

    [Comment("Class for Pig")]  // Атрибут CommentAttribute для указания комментария к классу.
    public class Pig : Animal  // Объявление класса Pig, который наследует от абстрактного класса Animal.
    {
        // Конструктор класса Pig.
        public Pig(string Country, string HideFromOtherAnimal, string Name, string WhatAnimal) : base(Country, HideFromOtherAnimal, Name, WhatAnimal)
        {
            // Вызов конструктора базового класса Animal для инициализации свойств.
        }

        // Переопределенный метод SayHello.
        public override void SayHello()
        {
            base.SayHello();  // Вызов метода базового класса.
            Console.WriteLine(", i'm a Pig.");  // Вывод строки в консоль.
        }

        // Переопределенный метод GetFavoriteFood.
        public override eFavoriteFood GetFavoriteFood()
        {
            return base.GetFavoriteFood();  // Вызов метода базового класса и возвращение его значения.
        }
    }

    [Comment("Class for Animal")]  // Атрибут CommentAttribute для указания комментария к абстрактному классу Animal.
    abstract public class Animal  // Объявление абстрактного класса Animal.
    {
        // Автоматические свойства для хранения данных о животном.
        public string? Country { get; set; }
        public string? HideFromOtherAnimal { get; set; }
        public string? Name { get; set; }
        public string? WhatAnimal { get; set; }
        public eClassificationAnimal ClassificationAnimal { get; set; }
        public eFavoriteFood FavoriteFood { get; set; }

        // Конструктор класса Animal.
        public Animal(string Country, string HideFromOtherAnimal, string Name, string WhatAnimal)
        {
            // Инициализация свойств.
            this.Country = Country;
            this.HideFromOtherAnimal = HideFromOtherAnimal;
            this.Name = Name;
            this.WhatAnimal = WhatAnimal;
        }

        // Метод Deconstruct для деконструкции объекта Animal.
        public void Deconstruct(string Country, string HideFromOtherAnimal, string Name, string WhatAnimal)
        {
            Country = this.Country;
            HideFromOtherAnimal = this.HideFromOtherAnimal;
            Name = this.Name;
            WhatAnimal = this.WhatAnimal;
        }

        // Свойство GetClassificationAnimal для получения классификации животного.
        public eClassificationAnimal GetClassificationAnimal()
        {
            return this.ClassificationAnimal;
        }

        // Виртуальный метод GetFavoriteFood для получения любимой пищи животного.
        public virtual eFavoriteFood GetFavoriteFood()
        {
            return this.FavoriteFood;
        }
        public virtual void SayHello()
        {
            Console.Write("Hello ");
        }
    }
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }
    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }
}