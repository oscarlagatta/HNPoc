using System;
using Core.Common.Core;

namespace HN.Wow.Client.Entities
{
    public class Product : ObjectBase
    {
        private int _productId;
      
        private string _productName;

        private decimal _cost;

        private decimal _price;

        private DateTime _introductionDate;

        private bool _isDiscontinued;

        private int _accountId;

        private int _stock;

        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(() => ProductId);
                }
            }
        }

        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(() => ProductName);
                }
            }
        }

        public DateTime IntroductionDate
        {
            get { return _introductionDate; }
            set
            {
                if (_introductionDate != value)
                {
                    _introductionDate = value;
                    OnPropertyChanged(() => IntroductionDate);
                }
            }
        }

        public decimal Cost
        {
            get { return _cost; }
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    OnPropertyChanged(() => Cost);
                }
            }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(() => ProductName);
                }
            }
        }

        public bool IsDiscontinued
        {
            get { return _isDiscontinued; }
            set
            {
                if (_isDiscontinued != value)
                {
                    _isDiscontinued = value;
                    OnPropertyChanged(() => IsDiscontinued);
                }
            }
        }
        public int AccountId
        {
            get { return _accountId; }
            set
            {
                if (_accountId != value)
                {
                    _accountId = value;
                    OnPropertyChanged(() => AccountId);
                }
            }
        }
        
        public int Stock
        {
            get { return _stock; }
            set
            {
                if (_stock != value)
                {
                    _stock = value;
                    OnPropertyChanged(() => Stock);
                }
            }
        }
    }
}
