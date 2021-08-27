using System;

namespace DontRepeatYourself
{
    class Order
    {
        public string CustomerId { get; }
        public string ProductId { get; }

        public Order(string customerId, string productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }

    class OnlineStore
    {
        //below code breaks the DRY principle as 30-days policy is defined in two places
        //but it doesn't contain repeated code
        //public DateTime ReturnDateDeadline(DateTime purchaseDate)
        //{
        //    return purchaseDate.AddDays(30);
        //}

        //public bool IsAfterPossibleReturnDate(DateTime purchaseDate)
        //{
        //    return (DateTime.Now - purchaseDate).TotalDays > 30;
        //}


        //the below are the same by coincidence - we should NOT have one constant for it
        public const int DaysForReturn = 30;
        public const int DaysForRefund = 30;

        public DateTime ReturnDateDeadline(DateTime purchaseDate)
        {
            return purchaseDate.AddDays(DaysForReturn);
        }

        public bool IsAfterPossibleReturnDate(DateTime purchaseDate)
        {
            return IsBeforeNow(ReturnDateDeadline(purchaseDate));
        }

        public DateTime RefundDateDeadline(DateTime purchaseDate)
        {
            return purchaseDate.AddDays(DaysForRefund);
        }

        public bool IsAfterPossibleRefundDate(DateTime purchaseDate)
        {
            return IsBeforeNow(RefundDateDeadline(purchaseDate));
        }

        private bool IsBeforeNow(DateTime dateTime)
        {
            return dateTime < DateTime.Now;
        }

        //below code doesn't break the DRY principle - business requirement is only defined once
        //but it does contain repeated code

        //public void CommitOrder(Order order)
        //{
        //    if(string.IsNullOrEmpty(order.CustomerId))
        //    {
        //        throw new Exception($"The CustomerId must not be empty");
        //    }
        //    if (string.IsNullOrEmpty(order.ProductId))
        //    {
        //        throw new Exception($"The ProductId must not be empty");
        //    }

        //    //saving to database here...
        //    Console.WriteLine("Order committed and saved to database");
        //}

        public void CommitOrder(Order order)
        {
            Validate(order.CustomerId, nameof(order.CustomerId));
            Validate(order.ProductId, nameof(order.ProductId));

            //saving to database here...
            Console.WriteLine("Order committed and saved to database");
        }

        private void Validate(string idToBeValidated, string propertyName)
        {
            if (string.IsNullOrEmpty(idToBeValidated))
            {
                throw new Exception($"The {propertyName} must not be empty");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var onlineStore = new OnlineStore();

            var purchaseDate = new DateTime(2021, 6, 21);
            Console.WriteLine($"Purchase date: {purchaseDate}");
            Console.WriteLine($"Return deadline: {onlineStore.ReturnDateDeadline(purchaseDate)}");
            Console.WriteLine($"Is after return deadline: {onlineStore.IsAfterPossibleReturnDate(purchaseDate)}\n");

            var olderPurchaseDate = new DateTime(2020, 6, 21);
            Console.WriteLine($"Purchase date: {olderPurchaseDate}");
            Console.WriteLine($"Return deadline: {onlineStore.ReturnDateDeadline(olderPurchaseDate)}");
            Console.WriteLine($"Is after return deadline: {onlineStore.IsAfterPossibleReturnDate(olderPurchaseDate)}\n");

            //the below will thrown an exception on validation
            //onlineStore.CommitOrder(new Order(null, null));

            Console.ReadKey();
        }
    }
}
