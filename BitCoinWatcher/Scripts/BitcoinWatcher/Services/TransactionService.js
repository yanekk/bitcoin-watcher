var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.Services = BitcoinWatcher.Services || {};

BitcoinWatcher.Services.TransactionService = function() {
    "use strict";
    var self = this;

    self.getTransactions = function() {
        return $.deferredClosure(function(deferred) {
            $.getJson("/transactions")
                .done(function(transactions) {
                    deferred.resolve(transactions);
                });
        });
    }

    self.addTransaction = function (transaction) {
        return $.deferredClosure(function(deferred) {
            $.postJson("/transactions", transaction)
                .done(function(response) {
                    deferred.resolve(response);
                });
        });
    }

    self.removeTransaction = function (transactionId) {
        return $.deferredClosure(function (deferred) {
            $.deleteJson("/transactions/" + transactionId)
                .done(function (response) {
                    deferred.resolve(response);
                });
        });
    }
}