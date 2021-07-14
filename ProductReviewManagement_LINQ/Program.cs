using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewManagement_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To The Product Review Management");

            List<ProductReview> list = new List<ProductReview>()
            {
                    new ProductReview() { ProductId=1,  UserId=1, Rating=5, Review="Good", isLike=true},
                    new ProductReview() { ProductId = 1, UserId = 1, Rating = 5, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 2, UserId = 2, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 3, UserId = 3, Rating = 3, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 4, UserId = 4, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 5, UserId = 5, Rating = 5, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 6, UserId = 1, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 7, UserId = 2, Rating = 2, Review = "Good", isLike=false},
                    new ProductReview() { ProductId = 8, UserId = 3, Rating = 1.5, Review = "Good", isLike=false },
                    new ProductReview() { ProductId = 9, UserId = 4, Rating = 3.5, Review = "Bad", isLike=false },
                    new ProductReview() { ProductId = 10, UserId = 5, Rating = 5, Review = "Bad", isLike=false },
                    new ProductReview() { ProductId = 11, UserId = 6, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 12, UserId = 7, Rating = 3, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 13, UserId = 8, Rating = 1, Review = "Bad", isLike=true },
                    new ProductReview() { ProductId = 14, UserId = 11, Rating = 2, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 15, UserId = 5, Rating = 5, Review = "Bad", isLike=false },
                    new ProductReview() { ProductId = 16, UserId = 6, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 17, UserId = 7, Rating = 3, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 18, UserId = 8, Rating = 1, Review = "Bad", isLike=true },
                    new ProductReview() { ProductId = 19, UserId = 7, Rating = 2, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 20, UserId = 10, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 21, UserId = 5, Rating = 5, Review = "Bad", isLike=false },
                    new ProductReview() { ProductId = 22, UserId = 6, Rating = 4, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 23, UserId = 12, Rating = 3, Review = "Good", isLike=true },
                    new ProductReview() { ProductId = 24, UserId = 8, Rating = 1, Review = "Bad", isLike=true },
                    new ProductReview() { ProductId = 25, UserId = 9, Rating = 4, Review = "Good", isLike=true }
                    };

            foreach (var lists in list)
            {
                Console.WriteLine("Product id = " + lists.ProductId + " User id = " + lists.UserId + " Rating is = " + lists.Rating + " Review is = " + lists.Review + " isLike = " + lists.isLike);
            }
            Console.WriteLine("\n TOP_THREE_REVIEWS");
            Management management = new Management();
            management.TopRecord(list);

            Console.WriteLine("\n Select Record 1 , 4 , 9 Whos Rating > 3");
            management.SelectRecords(list);

            Console.WriteLine("\n Count of Records Using GroupBy");
            management.CountOfRecords(list);

            management.RetrieveIdAndReview(list);

            Console.WriteLine("\n Skip Top Five Records");
            management.SkipTopFiveRecord(list);

            Console.WriteLine("\n Data_Table");
            DataTable data = management.CreateTable(list);
            foreach (var table in list)
            {
                data.Rows.Add(table.ProductId, table.UserId, table.Rating, table.Review, table.isLike);
            }
            management.RetrieveRecordsWithisLikeTrue(data);

            Console.WriteLine("\n Get Average Rating Of Product");
            management.GetAvgRatings(list);
            Console.ReadKey();
        }

    }
}

