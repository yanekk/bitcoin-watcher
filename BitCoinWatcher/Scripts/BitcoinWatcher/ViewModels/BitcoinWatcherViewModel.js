var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.ViewModels = BitcoinWatcher.ViewModels || {};

BitcoinWatcher.ViewModels.BitcoinWatcherViewModel = function() {
    "use strict";
    var self = this;

    self.currencies = ko.observableArray();
    self.transactions = ko.observableArray();

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
    var interval = setInterval(function() {
            refresh();
        }, 15000);
}