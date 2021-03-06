﻿namespace TestingEntityRelations.Data
{
    public static class DataValidation
    {
        public static class Make
        {
            public const int MaxNameLength = 20;
        }

        public static class Model
        {
            public const int MaxNameLength = 20;
            public const int MaxModificationLength = 30;
        }
        
        public static class Car
        {
            public const int VinLength = 17;
            public const int ColorMaxLength = 15;
        }

        public static  class Customer
        {
            public const int MaxNameLength = 30;
        }

        public static class Address
        {
            public const int MaxTextLength = 200;
            public const int MaxTownLength = 50;
        }
    }

}
