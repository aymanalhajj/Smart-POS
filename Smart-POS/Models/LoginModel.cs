using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Desktop.Models
{
    class LoginModel
    {
        public string? username { get; set; }
        public string? password { get; set; }

    }

    class LoginResponseModel
    {
        public string? token { get; set; }
        public string? message { get; set; }
        public string? status { get; set; }

    }

    public class InvoiceDetailItem : INotifyPropertyChanged
    {
        public int ProductId { get; set; }
        public string? _product_barcode;

        public int _product_unit_id;
        public string? _price;
        public string? _total_price;
        public string? _discount_percentage;
        public string? _discount_value;
        public string? _post_discount_price;


        public string? _vat_percentage;
        public string? _vat_value;
        public string? _total_amount;
        public string? _change_total_amount;

        public string? _quantity;
        public string? ProductBarcode
        {
            get
            {
                if (_product_barcode == null)
                {
                    _product_barcode = "";
                }
                return _product_barcode;
            }
            set
            {
                _product_barcode = value;
                OnPropertyChanged("ProductBarcode");
            }
        }
        public string? Quantity
        {
            get
            {
                if (_quantity == null)
                {
                    _quantity = "";
                }
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        public int ProductUnitId
        {
            get
            {
                if (_product_unit_id == null)
                {
                    _product_unit_id = 1;
                }
                return _product_unit_id;
            }
            set
            {
                _product_unit_id = value;
                OnPropertyChanged("ProductUnitId");
            }
        }
        public string? Price
        {
            get
            {
                if (_price == null)
                {
                    _price = "";
                }
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public string? TotalPrice
        {
            get
            {
                if (_total_price == null)
                {
                    _total_price = "";
                }
                return _total_price;
            }
            set
            {
                _total_price = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        public string? DiscountPercentage
        {
            get
            {
                if (_discount_percentage == null)
                {
                    _discount_percentage = "";
                }
                return _discount_percentage;
            }
            set
            {
                _discount_percentage = value;
                OnPropertyChanged("DiscountPercentage");
            }
        }
        public string? DiscountValue
        {
            get
            {
                if (_discount_value == null)
                {
                    _discount_value = "";
                }
                return _discount_value;
            }
            set
            {
                _discount_value = value;
                OnPropertyChanged("DiscountValue");
            }
        }
        public string? PostDiscountPrice
        {
            get
            {
                if (_post_discount_price == null)
                {
                    _post_discount_price = "";
                }
                return _post_discount_price;
            }
            set
            {
                _post_discount_price = value;
                OnPropertyChanged("PostDiscountPrice");
            }
        }
        public string? VatPercentage
        {
            get
            {
                if (_vat_percentage == null)
                {
                    _vat_percentage = "";
                }
                return _vat_percentage;
            }
            set
            {
                _vat_percentage = value;
                OnPropertyChanged("VatPercentage");
            }
        }
        public string? VatValue
        {
            get
            {
                if (_vat_value == null)
                {
                    _vat_value = "";
                }
                return _vat_value;
            }
            set
            {
                _vat_value = value;
                OnPropertyChanged("VatValue");
            }
        }
        public string? TotalAmount
        {
            get
            {
                if (_total_amount == null)
                {
                    _total_amount = "";
                }
                return _total_amount;
            }
            set
            {
                _total_amount = value;
                OnPropertyChanged("TotalAmount");
            }
        }
        public string? ChangeTotalAmount
        {
            get
            {
                if (_change_total_amount == null)
                {
                    _change_total_amount = "";
                }
                return _change_total_amount;
            }
            set
            {
                _change_total_amount = value;
                OnPropertyChanged("ChangeTotalAmount");
            }
        }
        public string? PreDiscountVatValue { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PurchaseInvoice : INotifyPropertyChanged
    {
        public PurchaseInvoice()
        {
            InvoiceDate = DateTime.Now;
            ProviderInvDate = DateTime.Now;
            StoreDate = DateTime.Now;
            items = new List<InvoiceDetailItem> { new InvoiceDetailItem() };
            PaymentType = 1;
            InvoiceType = 1;
        }
        public int _invoice_id { get; set; }
        public int InvoiceId
        {
            get
            {
                return _invoice_id;
            }
            set
            {
                _invoice_id = value;
                OnPropertyChanged("InvoiceId");
            }
        }
        public int _invoice_no { get; set; }
        public int InvoiceNo
        {
            get
            {
                return _invoice_no;
            }
            set
            {
                _invoice_no = value;
                OnPropertyChanged("InvoiceNo");
            }
        }
        public object provider_inv_id;
        public object ProviderInvId
        {
            get
            {
                if (provider_inv_id == null)
                {
                    provider_inv_id = "0";
                }
                return provider_inv_id;
            }
            set
            {
                provider_inv_id = value;
                OnPropertyChanged("ProviderInvId");
            }
        }
        public object _notes { get; set; }
        public object Notes
        {
            get
            {
                if (_notes == null)
                {
                    _notes = "0";
                }
                return _notes;
            }
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }
        public object _invoice_date { get; set; }
        public object InvoiceDate
        {
            get
            {
                return _invoice_date;
            }
            set
            {
                _invoice_date = value;
                OnPropertyChanged("InvoiceDate");
            }
        }
        public object _provider_inv_date { get; set; }
        public object ProviderInvDate
        {
            get
            {
                if (_provider_inv_date == null)
                {
                    _provider_inv_date = "0";
                }
                return _provider_inv_date;
            }
            set
            {
                _provider_inv_date = value;
                OnPropertyChanged("ProviderInvDate");
            }
        }
        public object _store_date { get; set; }
        public object StoreDate
        {
            get
            {
                if (_store_date == null)
                {
                    _store_date = "0";
                }
                return _store_date;
            }
            set
            {
                _store_date = value;
                OnPropertyChanged("StoreDate");
            }
        }

        public object _branch_id { get; set; }
        public object BranchId
        {
            get
            {
                if (_branch_id == null)
                {
                    _branch_id = "0";
                }
                return _branch_id;
            }
            set
            {
                _branch_id = value;
                OnPropertyChanged("BranchId");
            }
        }
        public object _provider_id { get; set; }
        public object ProviderId
        {
            get
            {
                if (_provider_id == null)
                {
                    _provider_id = "0";
                }
                return _provider_id;
            }
            set
            {
                _provider_id = value;
                OnPropertyChanged("ProviderId");
            }
        }
        public object _cost_ctr_id { get; set; }
        public object CostCenterId
        {
            get
            {
                return _cost_ctr_id;
            }
            set
            {
                _cost_ctr_id = value;
                OnPropertyChanged("CostCenterId");
            }
        }
        public object _invoice_type { get; set; }
        public object InvoiceType
        {
            get
            {
                if (_invoice_type == null)
                {
                    _invoice_type = "0";
                }
                return _invoice_type;
            }
            set
            {
                _invoice_type = value;
                OnPropertyChanged("InvoiceType");
            }
        }
        public object _store_id { get; set; }
        public object StoreId
        {
            get
            {
                return _store_id;
            }
            set
            {
                _store_id = value;
                OnPropertyChanged("StoreId");
            }
        }
        public int safe_id { get; set; }
        public int SafeId
        {
            get
            {
                return safe_id;
            }
            set
            {
                safe_id = value;
                OnPropertyChanged("SafeId");
            }
        }


        public List<InvoiceDetailItem> items { get; set; }

        public int _payment_type { get; set; }
        public int PaymentType
        {
            get
            {
                return _payment_type;
            }
            set
            {
                _payment_type = value;
                OnPropertyChanged("PaymentType");
            }
        }
        public double _pre_tax_total_amount { get; set; }
        public double PreTaxTotalAmount
        {
            get
            {
                return _pre_tax_total_amount;
            }
            set
            {
                _pre_tax_total_amount = value;
                OnPropertyChanged("PreTaxTotalAmount");
            }
        }
        public double _client_discount { get; set;
        public double ClientDiscount
        {
            get
            {
                return _client_discount;
            }
            set
            {
                _client_discount = value;
                OnPropertyChanged("ClientDiscount");
            }
        }
        public double _total_discount { get; set; }
        public double TotalDiscount
        {
            get
            {
                return _total_discount;
            }
            set
            {
                _total_discount = value;
                OnPropertyChanged("TotalDiscount");
            }
        }
        public double _post_discount_total_amount { get; set; }
        public double PostDiscountTotalAmount
        {
            get
            {
                return _post_discount_total_amount;
            }
            set
            {
                _post_discount_total_amount = value;
                OnPropertyChanged("PostDiscountTotalAmount");
            }
        }
        public double _total_vat { get; set; }
        public double TotalVat
        {
            get
            {
                return _total_vat;
            }
            set
            {
                _total_vat = value;
                OnPropertyChanged("TotalVat");
            }
        }
        public int _total_quantity { get; set; }
        public int TotalQuantity
        {
            get
            {
                return _total_quantity;
            }
            set
            {
                _total_quantity = value;
                OnPropertyChanged("TotalQuantity");
            }
        }
        public int _invoice_total_amount { get; set; }
        public int InvoiceTotalAmount
        {
            get
            {
                return _invoice_total_amount;
            }
            set
            {
                _invoice_total_amount = value;
                OnPropertyChanged("InvoiceTotalAmount");
            }
        }
        public object _paid_cash_amount { get; set; }
        public object PaidCashAmount
        {
            get
            {
                return _paid_cash_amount;
            }
            set
            {
                _paid_cash_amount = value;
                OnPropertyChanged("PaidCashAmount");
            }
        }
        public object _paid_bank_amount { get; set; }
        public object PaidBankAmount
        {
            get
            {
                return _paid_bank_amount;
            }
            set
            {
                _paid_bank_amount = value;
                OnPropertyChanged("PaidBankAmount");
            }
        }
        public int _company_id { get; set; }
        public int CompanyId
        {
            get
            {
                return _company_id;
            }
            set
            {
                _company_id = value;
                OnPropertyChanged("CompanyId");
            }
        }
        public int _user_id { get; set; }
        public int UserId
        {
            get
            {
                return _user_id;
            }
            set
            {
                _user_id = value;
                OnPropertyChanged("UserId");
            }
        }
        public int _bank_acc_id { get; set; }
        public int BankAccId
        {
            get
            {
                return _bank_acc_id;
            }
            set
            {
                _bank_acc_id = value;
                OnPropertyChanged("BankAccId");
            }
        }
        public object _paid_amount { get; set; }
        public object PaidAmount
        {
            get
            {
                return _paid_amount;
            }
            set
            {
                _paid_amount = value;
                OnPropertyChanged("PaidAmount");
            }
        }
        public object _deferred_amount { get; set; }
        public object DeferredAmount
        {
            get
            {
                return _deferred_amount;
            }
            set
            {
                _deferred_amount = value;
                OnPropertyChanged("DeferredAmount");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        #region INotifyPropertyChanged Members

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class PurchaseInvoicesResponse
    {
        public List<PurchaseInvoice> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
    public class LOV
    {
        public List<Item>? Items { get; set; }

    }
    public class Item
    {

        public string? name { get; set; }
        public int id { get; set; }
    }
    public enum PaymentType
    {
        Cash,
        Network
    }

}
