var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.Services = BitcoinWatcher.Services || {};

BitcoinWatcher.Services.CoinItemService = function() {
    "use strict";
    var self = this;

    self.getCoinItems = function() {
        return $.deferredClosure(function(deferred) {
            $.getJson("/coins")
                .done(function(coinItems) {
                    deferred.resolve(coinItems);
                });
        });
    }

    self.addCoinItem = function(coinItem) {
        return $.deferredClosure(function(deferred) {
            $.postJson("/coins", coinItem)
                .done(function(response) {
                    deferred.resolve(response);
                });
        });
    }

    self.removeCoinItem = function (coinItemId) {
        return $.deferredClosure(function (deferred) {
            $.deleteJson("/coins/"+coinItemId)
                .done(function (response) {
                    deferred.resolve(response);
                });
        });
    }
}