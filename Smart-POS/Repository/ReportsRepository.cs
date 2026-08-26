using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using Smart_POS.Models;

namespace Smart_POS.Repository
{
    public class ReportsRepository : ApiRepository
    {
        private static string DateParam(DateTime? date) => date?.ToString("yyyy-MM-dd") ?? "";

        private ReportResult<T> Get<T>(string path, Dictionary<string, string> extraParams, int page, int pageSize)
        {
            try
            {
                var query = $"p_company_id={HttpUtility.UrlEncode(companyId)}" +
                            $"&p_lang_id={HttpUtility.UrlEncode(langId)}" +
                            $"&page={page}&page_size={pageSize}";
                foreach (var kv in extraParams)
                {
                    if (!string.IsNullOrEmpty(kv.Value))
                    {
                        query += $"&{kv.Key}={HttpUtility.UrlEncode(kv.Value)}";
                    }
                }
                var requestUri = new Uri($"{baseUrl}{path}?{query}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("مشكلة في الوصول." + response.Content.ReadAsStringAsync().Result);
                    return new ReportResult<T> { Items = new List<T>() };
                }
                var res = JsonConvert.DeserializeObject<ReportResult<T>>(response.Content.ReadAsStringAsync().Result);
                return res ?? new ReportResult<T> { Items = new List<T>() };
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
                return new ReportResult<T> { Items = new List<T>() };
            }
        }

        public ReportResult<SafeBalanceRow> GetSafeBalances(DateTime? fromDate, DateTime? toDate, string? safeId, int page, int pageSize) =>
            Get<SafeBalanceRow>("reports/accounting/safe-balances", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
                { "p_safe_id", safeId ?? "" },
            }, page, pageSize);

        public ReportResult<BankBalanceRow> GetBankBalances(DateTime? fromDate, DateTime? toDate, string? bankId, int page, int pageSize) =>
            Get<BankBalanceRow>("reports/accounting/bank-balances", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
                { "p_bank_id", bankId ?? "" },
            }, page, pageSize);

        public ReportResult<IncomeStatementRow> GetIncomeStatement(DateTime? toDate, string? costCtrId, bool withMainAccs, int page, int pageSize) =>
            Get<IncomeStatementRow>("reports/accounting/income-statement", new Dictionary<string, string>
            {
                { "p_to_date", DateParam(toDate) },
                { "p_cost_cntr_id", costCtrId ?? "" },
                { "p_with_main_accs", withMainAccs ? "1" : "0" },
            }, page, pageSize);

        public ReportResult<TrialBalanceRow> GetTrialBalance(DateTime? fromDate, DateTime? toDate, string? costCtrId, bool withMainAccs, int page, int pageSize) =>
            Get<TrialBalanceRow>("reports/accounting/trial-balance", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
                { "p_cost_cntr_id", costCtrId ?? "" },
                { "p_with_main_accs", withMainAccs ? "1" : "0" },
            }, page, pageSize);

        public ReportResult<InvoiceTotalByClientRow> GetInvoiceByClient(DateTime? fromDate, DateTime? toDate, string? clientId, int page, int pageSize) =>
            Get<InvoiceTotalByClientRow>("reports/sales/invoice-by-client", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
                { "p_client_id", clientId ?? "" },
            }, page, pageSize);

        public ReportResult<InvoiceTotalByTypeRow> GetInvoiceByType(DateTime? fromDate, DateTime? toDate, int page, int pageSize) =>
            Get<InvoiceTotalByTypeRow>("reports/sales/invoice-by-type", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
            }, page, pageSize);

        public ReportResult<PurchasesPeriodRow> GetPurchasesPeriod(DateTime? fromDate, DateTime? toDate, int page, int pageSize) =>
            Get<PurchasesPeriodRow>("reports/sales/purchases-period", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
            }, page, pageSize);

        public ReportResult<EmployeeSalesRow> GetEmployeeSales(DateTime? fromDate, DateTime? toDate, string? userId, int page, int pageSize) =>
            Get<EmployeeSalesRow>("reports/sales/employee-sales", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
                { "p_user_id", userId ?? "" },
            }, page, pageSize);

        public ReportResult<ProductSalesPurchasesRow> GetProductSalesPurchases(DateTime? fromDate, DateTime? toDate, int page, int pageSize) =>
            Get<ProductSalesPurchasesRow>("reports/sales/product-sales-purchases", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
            }, page, pageSize);

        public ReportResult<ClientSalesReturnsRow> GetClientSalesReturns(DateTime? fromDate, DateTime? toDate, string? clientId, int page, int pageSize) =>
            Get<ClientSalesReturnsRow>("reports/sales/client-sales-returns", new Dictionary<string, string>
            {
                { "p_from_date", DateParam(fromDate) },
                { "p_to_date", DateParam(toDate) },
                { "p_client_id", clientId ?? "" },
            }, page, pageSize);

        public ReportResult<ProductTransRow> GetProductTransactions(string? productId, int page, int pageSize) =>
            Get<ProductTransRow>("reports/store/product-transactions", new Dictionary<string, string>
            {
                { "p_product_id", productId ?? "" },
            }, page, pageSize);

        public ReportResult<StoresStatisticsRow> GetStoresStatistics(string? storeId, int page, int pageSize) =>
            Get<StoresStatisticsRow>("reports/store/stores-statistics", new Dictionary<string, string>
            {
                { "p_store_id", storeId ?? "" },
            }, page, pageSize);

        public ReportResult<StoresStatisticsRow> GetStoresStatisticsToDate(DateTime? toDate, string? storeId, int page, int pageSize) =>
            Get<StoresStatisticsRow>("reports/store/stores-statistics-to-date", new Dictionary<string, string>
            {
                { "p_to_date", DateParam(toDate) },
                { "p_store_id", storeId ?? "" },
            }, page, pageSize);

        public byte[]? GetReportPdf(string reportName, Dictionary<string, string> parameters)
        {
            try
            {
                var query = string.Join("&", parameters.Select(kv => $"{HttpUtility.UrlEncode(kv.Key)}={HttpUtility.UrlEncode(kv.Value)}"));
                var requestUri = new Uri($"{baseUrl}report?reportName={HttpUtility.UrlEncode(reportName)}&format=pdf&{query}", UriKind.Absolute);
                var response = ApiRepository.getInstance().MyClient().GetAsync(requestUri).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    Utils.ShowMessage("تعذرت طباعة التقرير." + response.Content.ReadAsStringAsync().Result);
                    return null;
                }
                return response.Content.ReadAsByteArrayAsync().Result;
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(ex.Message);
                return null;
            }
        }
    }
}
