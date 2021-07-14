using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;

namespace ProductReviewManagement_LINQ
{
    class Management
    {
        /// <summary>
        /// Method For Top Three Records
        /// var : It carries all The Data Type
        /// </summary>
        public readonly DataTable dataTable = new DataTable();

        public void TopRecord(List<ProductReview> listProductReview)
        {
            var recordData = (from productReview in listProductReview
                              orderby productReview.Rating descending //By Default It Will Take values In Ascending Order
                              select productReview).Take(3);

            foreach (var list in recordData) //We Can use class Type Instead Of var Keyword
            {
                Console.WriteLine("Product id = " + list.ProductId + " User id = " + list.UserId + " Rating is = " + list.Rating + " Review is = " + list.Review + " isLike = " + list.isLike);
            }
        }
        /// <summary>
        /// Method For Selected Records
        /// alias : productReview
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            var recordData = (from productReview in listProductReview
                              where (productReview.ProductId == 1 || productReview.ProductId == 4 || productReview.ProductId == 9)
                              && productReview.Rating > 3
                              select productReview).ToList();

            DisplayRecord(recordData);
        }
        /// <summary>
        /// Method To Display List
        /// </summary>
        /// <param name="record"></param>
        public void DisplayRecord(List<ProductReview> record)
        {
            foreach (var lists in record)
            {
                Console.WriteLine("Product id = " + lists.ProductId + " User id = " + lists.UserId + " Rating is = " + lists.Rating + " Review is = " + lists.Review + " isLike = " + lists.isLike);
            }
        }
        public void CountOfRecords(List<ProductReview> listProductReview)
        {
            var recordData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductID = x.Key, Count = x.Count() });

            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductID + "-----" + list.Count);
            }
        }
        public void RetrieveIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { ProductID = x.ProductId, Review = x.Review });
            Console.WriteLine("ID  And Review");
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "---->" + list.Review);
            }
        }
        public void SkipTopFiveRecord(List<ProductReview> listProductReview)
        {
            var recordData = (from productReview in listProductReview
                              orderby productReview.Rating descending
                              select productReview).Skip(5).ToList();

            DisplayRecord(recordData);
        }
        public DataTable CreateTable(List<ProductReview> productReview)
        {
            var tableColumn1 = new DataColumn("ProductId", typeof(int));
            dataTable.Columns.Add(tableColumn1);
            var tableColumn2 = new DataColumn("UserId", typeof(int));
            dataTable.Columns.Add(tableColumn2);
            var tableColumn3 = new DataColumn("Rating", typeof(double));
            dataTable.Columns.Add(tableColumn3);
            var tableColumn4 = new DataColumn("Review");
            dataTable.Columns.Add(tableColumn4);
            var tableColumn5 = new DataColumn("isLike", typeof(bool));
            dataTable.Columns.Add(tableColumn5);
            return dataTable;
        }
        public void RetrieveRecordsWithisLikeTrue(DataTable table)
        {
            var recordedData = from productReviews in table.AsEnumerable()
                               where (productReviews.Field<bool>("isLike") == true)
                               select productReviews;
            Console.WriteLine("Records with isLike=true Value");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.Field<int>("ProductID") + " " + "UserID:- " + list.Field<int>("UserID")
                    + " " + "Rating:- " + list.Field<double>("Rating") + " " + "Review:- " + list.Field<string>("Review") + " " + "isLike:- " + list.Field<bool>("isLike"));
            }
        }
        public void GetAvgRatings(List<ProductReview> listProductReview)
        {
            Console.WriteLine("\n ID Avg Rating");
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { id = x.Key, avg = x.Average(y => y.Rating) });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.id + "----->" + list.avg);
            }
        }
        public void GetNiceReview(List<ProductReview> listproductReview)
        {
            var recordData = (from ProductReview in listproductReview
                              where (ProductReview.Review.Equals("Nice"))
                              select ProductReview).ToList();
            DisplayRecord(recordData);
        }
    }
}

