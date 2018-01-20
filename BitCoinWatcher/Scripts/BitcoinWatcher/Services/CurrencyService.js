var BitcoinWatcher = BitcoinWatcher || {};
BitcoinWatcher.Services = BitcoinWatcher.Services || {};

BitcoinWatcher.Services.CurrencyService = function() {
    "use strict";
    var self = this;

    self.getCurrencies = function() {
        return $.deferredClosure(function(deferred) {
            $.getJson("/currency")
                .done(function(currencies) {
                    deferred.resolve(currencies);
                });
        });
    }
}