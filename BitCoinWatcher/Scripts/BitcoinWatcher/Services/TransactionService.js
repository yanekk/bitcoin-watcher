var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.Services = BitcoinWatcher.Services || {};

BitcoinWatcher.Services.TransactionService = function() {
    "use strict";
    var self = this;

    self.getTransactions = function() {
        return $.deferredClosure(function(deferred) {
            $.getJson("/transactions")
                .done(function(coinItems) {
                    deferred.resolve(coinItems);
                });
        });
    }

    self.addTransaction = function(coinItem) {
        return $.deferredClosure(function(deferred) {
            $.postJson("/transactions", coinItem)
                .done(function(response) {
                    deferred.resolve(response);
                });
        });
    }

    self.removeTransaction = function (coinItemId) {
        return $.deferredClosure(function (deferred) {
            $.deleteJson("/transactions/"+coinItemId)
                .done(function (response) {
                    deferred.resolve(response);
                });
        });
    }
}