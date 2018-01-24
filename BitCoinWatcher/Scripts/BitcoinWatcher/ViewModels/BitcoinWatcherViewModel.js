var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.ViewModels = BitcoinWatcher.ViewModels || {};

BitcoinWatcher.ViewModels.BitcoinWatcherViewModel = function() {
    "use strict";
    var self = this;

    self.currencies = ko.observableArray();
    self.transactions = ko.observableArray();

    self.totalAmountSpent = ko.computed(function() {
        return _.reduce(self.transactions(),
            function(total, transactionGroup) {
                return total +
                    _.reduce(transactionGroup.transactions,
                        function(totalInGroup, transaction) {
                            return totalInGroup + transaction.amountSpent;
                        }, 0);
            }, 0);
    });

    self.totalProfit = ko.computed(function () {
        return _.reduce(self.transactions(),
            function (total, transactionGroup) {
                return total +
                    _.reduce(transactionGroup.transactions,
                        function (totalInGroup, transaction) {
                            return totalInGroup + transaction.profit;
                        }, 0);
            }, 0);
    });
    var currencyService = new BitcoinWatcher.Services.CurrencyService();
    currencyService
        .getCurrencies()
        .done(function(currencies) {
            self.currencies(currencies);
        });

    var transactionService = new BitcoinWatcher.Services.TransactionService();
    var refresh = function() {
        transactionService
            .getTransactions()
            .done(function(transactions) {
                self.transactions(transactions);
            });
    }

    self.addTransaction = function(form) {
        transactionService
            .addTransaction($(form).serializeObject())
            .done(function(validationResult) {
                refresh();
            });
    }

    self.removeTransaction = function (coinItemId) {
        if (confirm("Czy na pewno chcesz usunąć transakcję?")) {
            transactionService
                .removeTransaction(coinItemId)
                .done(function(validationResult) {
                    refresh();
                });
        }
    }
    refresh();
}