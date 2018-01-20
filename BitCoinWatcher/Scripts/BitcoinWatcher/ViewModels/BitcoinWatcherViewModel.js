var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.ViewModels = BitcoinWatcher.ViewModels || {};

BitcoinWatcher.ViewModels.BitcoinWatcherViewModel = function() {
    "use strict";
    var self = this;

    self.currencies = ko.observableArray();
    self.coinItems = ko.observableArray();

    var currencyService = new BitcoinWatcher.Services.CurrencyService();
    currencyService
        .getCurrencies()
        .done(function(currencies) {
            self.currencies(currencies);
        });

    var coinItemService = new BitcoinWatcher.Services.CoinItemService();
    var refresh = function() {
        coinItemService
            .getCoinItems()
            .done(function(coinItems) {
                self.coinItems(coinItems);
            });
    }

    self.addCoinItem = function(form) {
        coinItemService
            .addCoinItem($(form).serializeObject())
            .done(function(validationResult) {
                refresh();
            });
    }

    self.removeCoinItem = function (coinItemId) {
        if (confirm("Czy na pewno chcesz usunąć?")) {
            coinItemService
                .removeCoinItem(coinItemId)
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