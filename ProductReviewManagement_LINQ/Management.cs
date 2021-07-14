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
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            var recordData = (from productReview in listProductReview
                              where (productReview.ProductId == 1 || productReview.ProductId == 4 || productReview.ProductId == 9)
                              && productReview.Rating > 3
                              select productReview).ToList();

            DisplayRecord(recordData);
        }

        public void DisplayRecord(List<ProductReview> record)
        {
            foreach (var lists in record)
            {
                Console.WriteLine("Product id = " + lists.ProductId + " User id = " + lists.UserId + " Rating is = " + lists.Rating + " Review is = " + lists.Review + " isLike = " + lists.isLike);
            }
        }
    }
}

